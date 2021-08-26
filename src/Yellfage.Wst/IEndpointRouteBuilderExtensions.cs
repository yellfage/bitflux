using System;

using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

using Yellfage.Wst.Interior;
using Yellfage.Wst.Interior.Mapping;

namespace Yellfage.Wst
{
    public static class IEndpointRouteBuilderExtensions
    {
        public static IWstHubEndpointConventionBuilder<TMarker> MapWstHub<TMarker>(
            this IEndpointRouteBuilder endpoints,
            string pattern)
        {
            EnsureServicesConfigured(endpoints.ServiceProvider);

            // We do not need to dispose the created scope,
            // because we are using scoped services until the application shutdown

            return endpoints
                .ServiceProvider
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<IHubMapper>()
                .Map<TMarker>(endpoints, pattern);
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
