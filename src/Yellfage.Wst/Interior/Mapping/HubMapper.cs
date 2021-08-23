using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Yellfage.Wst.Filtration;
using Yellfage.Wst.Configuration;
using Yellfage.Wst.Communication;
using Yellfage.Wst.Interior.Filtration;
using Yellfage.Wst.Interior.Communication;

namespace Yellfage.Wst.Interior.Mapping
{
    internal class HubMapper : Mapper, IHubMapper
    {
        private IServiceProvider ServiceProvider { get; }
        private IProtocolStore ProtocolStore { get; }
        private IHubFilterStore HubFilterStore { get; }
        private IRequestProcessor RequestProcessor { get; }
        private IWstHubEndpointConventionBuilderFactory HubEndpointConventionBuilderFactory { get; }

        public HubMapper(
            IFilterScreener filterScreener,
            IFilterExplorer filterExplorer,
            IServiceProvider serviceProvider,
            IProtocolStore protocolStore,
            IHubFilterStore hubFilterStore,
            IRequestProcessor requestProcessor,
            IWstHubEndpointConventionBuilderFactory hubEndpointConventionBuilderFactory) : base(
                filterScreener,
                filterExplorer)
        {
            ServiceProvider = serviceProvider;
            ProtocolStore = protocolStore;
            HubFilterStore = hubFilterStore;
            RequestProcessor = requestProcessor;
            HubEndpointConventionBuilderFactory = hubEndpointConventionBuilderFactory;
        }

        public IWstHubEndpointConventionBuilder<TMarker> Map<TMarker>(
            IEndpointRouteBuilder endpoints,
            string pattern)
        {
            HubOptions<TMarker> options = ResolveHubOptions<TMarker>();

            options.Validate();

            InitializeProtocols(options.Communication.Protocols);

            IHub<TMarker> hub = ResolveHub<TMarker>();

            IEnumerable<IFilter> filters = ResolveFilters(hub.GetType());

            HubFilterStore.AddRange(filters);

            RequestDelegate pipeline = endpoints
                .CreateApplicationBuilder()
                .UseWebSockets(CreateWebSocketOptions(options.Communication))
                .Use((context, _) => RequestProcessor.ProcessAsync<TMarker>(context))
                .Build();

            IEndpointConventionBuilder endpointConventionBuilder = endpoints.Map(pattern, pipeline);

            return HubEndpointConventionBuilderFactory.Create<TMarker>(endpointConventionBuilder);
        }

        private HubOptions<TMarker> ResolveHubOptions<TMarker>()
        {
            return ServiceProvider.GetRequiredService<HubOptions<TMarker>>();
        }

        private IHub<TMarker> ResolveHub<TMarker>()
        {
            return ServiceProvider.GetRequiredService<IHub<TMarker>>();
        }

        private void InitializeProtocols(IList<IProtocol> protocols)
        {
            if (!protocols.Any())
            {
                protocols.Add(new NewtonsoftJsonProtocol());
            }

            ProtocolStore.AddRange(protocols);
        }

        private WebSocketOptions CreateWebSocketOptions(CommunicationSettings settings)
        {
            var webSocketOptions = new WebSocketOptions()
            {
                KeepAliveInterval = settings.KeepAliveInterval
            };

            foreach (string origin in settings.AllowedOrigins)
            {
                webSocketOptions.AllowedOrigins.Add(origin);
            }

            return webSocketOptions;
        }
    }
}
