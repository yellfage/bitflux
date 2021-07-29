#pragma warning disable IDE0008

using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using Yellfage.Wst.Filters;
using Yellfage.Wst.Communication;
using Yellfage.Wst.Internal;
using Yellfage.Wst.Filters.Internal;
using Yellfage.Wst.Communication.Internal;

namespace Yellfage.Wst
{
    // TODO: validate options
    public static class IEndpointRouteBuilderExtensions
    {
        public static WstHubEndpointConventionBuilder<T> MapWstHub<T, THub>(
            this IEndpointRouteBuilder endpoints,
            string pattern) where THub : IHub<T>
        {
            return MapWstHub<T, THub>(endpoints, pattern, options => { });
        }

        public static WstHubEndpointConventionBuilder<T> MapWstHub<T, THub>(
            this IEndpointRouteBuilder endpoints,
            string pattern,
            Action<HubOptions> configure) where THub : IHub<T>
        {
            HubOptions options = new DefaultHubOptions();

            configure(options);

            return MapWstHub<T, THub>(endpoints, pattern, options);
        }

        public static WstHubEndpointConventionBuilder<T> MapWstHub<T, THub>(
            this IEndpointRouteBuilder endpoints,
            string pattern,
            HubOptions options) where THub : IHub<T>
        {
            WstMarkerService? markerService = endpoints
                .ServiceProvider
                .GetService<WstMarkerService>();

            if (markerService is null)
            {
                throw new InvalidOperationException(
                    "Required services not found. " +
                    "Please add all the required services by calling " +
                    "'IServiceCollection.AddWst' inside the 'ConfigureServices(...)' call " +
                    " in the application startup code");
            }

            THub? hub = endpoints.ServiceProvider.GetService<THub>();

            if (hub is null)
            {
                throw new InvalidOperationException(
                    $"Unable to resolve the {typeof(THub).FullName} instance." +
                    " Make sure you have added the Hub to the dependency injection container");
            }

            if (!options.Protocols.Any())
            {
                options.Protocols.Add(new NewtonsoftJsonProtocol());
            }

            IServiceProvider serviceProvider = endpoints.ServiceProvider;

            var filterExplorer = serviceProvider.GetRequiredService<IFilterExplorer>();
            var disabledFilterTypeExplorer = serviceProvider.GetRequiredService<IDisabledFilterTypeExplorer>();
            var filterSifter = serviceProvider.GetRequiredService<IFilterSifter>();
            var handlerExplorer = serviceProvider.GetRequiredService<IHandlerExplorer>();
            var handlerDescriptorFactory = serviceProvider.GetRequiredService<IHandlerDescriptorFactory>();

            IEnumerable<IFilter> filters = filterExplorer
                .ExploreAllFilters(hub.GetType())
                .OrderByDescending(filter => filter.Priority);

            var handlerDescriptors = new List<HandlerDescriptor>();

            var hubDescriptor = new HubDescriptor<T>(
                hub, serviceProvider, options, filters, handlerDescriptors);

            IRequestProcessor requestProcessor = SetupRequestProcessor(hubDescriptor);

            WebSocketOptions webSocketOptions = SetupWebSocketOptions(options);

            RequestDelegate pipeline = endpoints
                .CreateApplicationBuilder()
                .UseWebSockets(webSocketOptions)
                .Use(requestProcessor.ProcessAsync)
                .Build();

            IEndpointConventionBuilder endpointConventionBuilder = endpoints.Map(pattern, pipeline);

            return new WstHubEndpointConventionBuilder<T>(
                filterExplorer,
                disabledFilterTypeExplorer,
                filterSifter,
                handlerExplorer,
                handlerDescriptorFactory,
                endpointConventionBuilder,
                filters,
                handlerDescriptors);
        }

        private static IRequestProcessor SetupRequestProcessor<T>(HubDescriptor<T> hubDescriptor)
        {
            var filterExecutor = hubDescriptor.ServiceProvider.GetRequiredService<IFilterExecutor>();
            var handlerExecutor = hubDescriptor.ServiceProvider.GetRequiredService<IHandlerExecutor>();

            var protocolProvider = new ProtocolProvider(hubDescriptor.Options.Protocols);
            var filterProvider = new FilterProvider(hubDescriptor.Filters);

            var handlerDescriptorProvider = new HandlerDescriptorProvider(hubDescriptor.HandlerDescriptors);

            return new RequestProcessor<T>(
                hubDescriptor.Instance,
                protocolProvider,
                filterProvider,
                filterExecutor,
                handlerDescriptorProvider,
                handlerExecutor,
                hubDescriptor.ServiceProvider,
                hubDescriptor.Options);
        }

        private static WebSocketOptions SetupWebSocketOptions(HubOptions hubOptions)
        {
            var webSocketOptions = new WebSocketOptions()
            {
                KeepAliveInterval = hubOptions.KeepAliveInterval
            };

            foreach (string origin in hubOptions.AllowedOrigins)
            {
                webSocketOptions.AllowedOrigins.Add(origin);
            }

            return webSocketOptions;
        }
    }
}
