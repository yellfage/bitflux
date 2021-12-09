using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

using Yellfage.Wst.Communication;
using Yellfage.Wst.Interior;
using Yellfage.Wst.Interior.Communication;
using Yellfage.Wst.Interior.Connection;
using Yellfage.Wst.Interior.Mapping;

namespace Yellfage.Wst
{
    public static class IEndpointRouteBuilderExtensions
    {
        public static WstHubEndpointConventionBuilder MapWstHub<TMarker>(
            this IEndpointRouteBuilder builder,
            string pattern)
        {
            return builder.MapWstHub<TMarker>(pattern, builder => { });
        }

        public static WstHubEndpointConventionBuilder MapWstHub<TMarker>(
            this IEndpointRouteBuilder builder,
            string pattern,
            Action<IWstHubApplicationConfigurator<TMarker>> configure)
        {
            EnsureServicesConfigured<TMarker>(builder.ServiceProvider);
            EnsureReceptionsProvided<TMarker>(builder.ServiceProvider);
            EnsureProtocolsProvided<TMarker>(builder.ServiceProvider);

            MapWstHubAgreement<TMarker>(builder, pattern);

            IApplicationBuilder application = builder.CreateApplicationBuilder();

            IServiceProvider serviceProvider = application.ApplicationServices;

            configure(new WstHubApplicationConfigurator<TMarker>(application));

            serviceProvider.GetRequiredService<IHubMapper<TMarker>>().Map();

            application.Run((context) => serviceProvider
                .GetRequiredService<IConnectionRequestProcessor<TMarker>>()
                .ProcessAsync(context));

            IEndpointConventionBuilder endpointConventionBuilder = builder
                .Map(pattern, application.Build());

            return new WstHubEndpointConventionBuilder(endpointConventionBuilder);
        }

        private static IEndpointRouteBuilder MapWstHubAgreement<TMarker>(
            this IEndpointRouteBuilder builder,
            string pattern)
        {
            builder.MapGet($"{pattern.TrimEnd('/')}/agreement", async context =>
            {
                await builder
                    .ServiceProvider
                    .GetRequiredService<IAgreementRequestProcessor<TMarker>>()
                    .ProcessAsync(context);
            });

            return builder;
        }

        private static void EnsureServicesConfigured<TMarker>(IServiceProvider serviceProvider)
        {
            MarkerService<TMarker>? markerService = serviceProvider
                .GetService<MarkerService<TMarker>>();

            if (markerService is null)
            {
                throw new InvalidOperationException(
                    $"Unable to map the Hub with the \"{typeof(TMarker).Name}\" marker: " +
                    $"required services not found. " +
                    "Please add all the required services by calling " +
                    "\"IServiceCollection.AddWstHub<>(...)\" " +
                    $"inside the \"ConfigureServices(...)\" call " +
                    "in the application startup code");
            }
        }

        private static void EnsureReceptionsProvided<TMarker>(IServiceProvider serviceProvider)
        {
            IEnumerable<IReception<TMarker>> receptions = serviceProvider
                .GetRequiredService<IEnumerable<IReception<TMarker>>>();

            if (!receptions.Any())
            {
                throw new InvalidOperationException(
                    $"Unable to map a Hub with the \"{typeof(TMarker).Name}\" marker: " +
                    $"none {nameof(IReception<TMarker>)} is provided. " +
                    $"Please provide at least one {nameof(IReception<TMarker>)} by calling " +
                    $"\"IServiceCollection.AddWstHub<>(...).AddReception(...)\" " +
                    $"inside the 'ConfigureServices(...)' call " +
                    "in the application startup code");
            }
        }

        private static void EnsureProtocolsProvided<TMarker>(IServiceProvider serviceProvider)
        {
            IEnumerable<IProtocol<TMarker>> protocols = serviceProvider
                .GetRequiredService<IEnumerable<IProtocol<TMarker>>>();

            if (!protocols.Any())
            {
                throw new InvalidOperationException(
                    $"Unable to map a Hub with the \"{typeof(TMarker).Name}\" marker: " +
                    $"none {nameof(IProtocol<TMarker>)} is provided. " +
                    $"Please provide at least one {nameof(IProtocol<TMarker>)} by calling " +
                    $"\"IServiceCollection.AddWstHub<>(...).AddProtocol(...)\" " +
                    $"inside the 'ConfigureServices(...)' call " +
                    "in the application startup code");
            }
        }
    }
}
