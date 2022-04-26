using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

using Yellfage.Bitflux.Communication;
using Yellfage.Bitflux.Interior;
using Yellfage.Bitflux.Interior.Connection;
using Yellfage.Bitflux.Interior.Mapping;

namespace Yellfage.Bitflux
{
    public static class IEndpointRouteBuilderExtensions
    {
        public static BitfluxHubEndpointConventionBuilder MapBitfluxHub<TMarker>(
            this IEndpointRouteBuilder builder,
            string pattern)
        {
            return builder.MapBitfluxHub<TMarker>(pattern, builder => { });
        }

        public static BitfluxHubEndpointConventionBuilder MapBitfluxHub<TMarker>(
            this IEndpointRouteBuilder builder,
            string pattern,
            Action<IBitfluxHubApplicationConfigurator<TMarker>> configure)
        {
            EnsureServicesConfigured<TMarker>(builder.ServiceProvider);
            EnsureReceptionsProvided<TMarker>(builder.ServiceProvider);
            EnsureProtocolsProvided<TMarker>(builder.ServiceProvider);

            IApplicationBuilder application = builder.CreateApplicationBuilder();

            IServiceProvider serviceProvider = application.ApplicationServices;

            configure(new BitfluxHubApplicationConfigurator<TMarker>(application));

            serviceProvider.GetRequiredService<IHubMapper<TMarker>>().Map();

            application.Run((context) => serviceProvider
                .GetRequiredService<IConnectionRequestProcessor<TMarker>>()
                .ProcessAsync(context));

            IEndpointConventionBuilder endpointConventionBuilder = builder
                .Map(pattern, application.Build());

            return new BitfluxHubEndpointConventionBuilder(endpointConventionBuilder);
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
                    "\"IServiceCollection.AddBitfluxHub<>(...)\" " +
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
                    $"\"IServiceCollection.AddBitfluxHub<>(...).AddReception(...)\" " +
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
                    $"\"IServiceCollection.AddBitfluxHub<>(...).AddProtocol(...)\" " +
                    $"inside the 'ConfigureServices(...)' call " +
                    "in the application startup code");
            }
        }
    }
}
