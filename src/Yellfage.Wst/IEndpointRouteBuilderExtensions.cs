using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

using Yellfage.Wst.Interior;

namespace Yellfage.Wst
{
    public static class IEndpointRouteBuilderExtensions
    {
        public static IWstHubBuilder<TMarker> MapWstHub<TMarker>(
            this IEndpointRouteBuilder builder,
            string pattern)
        {
            return builder.MapWstHub<TMarker>(pattern, builder => { });
        }

        public static IWstHubBuilder<TMarker> MapWstHub<TMarker>(
            this IEndpointRouteBuilder builder,
            string pattern,
            Action<IApplicationBuilder> configureBuilder)
        {
            EnsureServicesConfigured(builder.ServiceProvider);

            // We do not need to dispose the created scope,
            // because we are using scoped services until the application shutdown
            IServiceScope scope = builder.ServiceProvider.CreateScope();

            IApplicationBuilder applicationBuilder = builder.CreateApplicationBuilder();

            applicationBuilder.ApplicationServices = scope.ServiceProvider;

            applicationBuilder
                .UseHubWebSocket<TMarker>()
                .UseWebSocketOnlyRestriction();

            configureBuilder(applicationBuilder);

            applicationBuilder.UseWebSocketAcceptance<TMarker>();

            return new WstHubBuilder<TMarker>(
                pattern,
                applicationBuilder,
                builder);
        }

        private static void EnsureServicesConfigured(IServiceProvider serviceProvider)
        {
            WstMarkerService? markerService = serviceProvider.GetService<WstMarkerService>();

            if (markerService is null)
            {
                throw new InvalidOperationException(
                    "Required services not found. " +
                    "Please add all the required services by calling " +
                    "'IServiceCollection.AddWst' inside the 'ConfigureServices(...)' call " +
                    "in the application startup code");
            }
        }
    }
}
