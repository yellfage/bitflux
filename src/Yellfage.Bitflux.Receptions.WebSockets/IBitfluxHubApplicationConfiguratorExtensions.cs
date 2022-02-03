using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Yellfage.Bitflux.Receptions.WebSockets
{
    public static class IBitfluxHubApplicationConfiguratorExtensions
    {
        public static IBitfluxHubApplicationConfigurator<TMarker> UseWebSocketReception<TMarker>(
            this IBitfluxHubApplicationConfigurator<TMarker> builder)
        {
            IServiceProvider serviceProvider = builder.Application.ApplicationServices;

            EnsureServicesConfigured<TMarker>(serviceProvider);

            IOptions<WebSocketReceptionOptions<TMarker>> receptionOptions = serviceProvider
                .GetRequiredService<IOptions<WebSocketReceptionOptions<TMarker>>>();

            var webSocketOptions = new WebSocketOptions()
            {
                KeepAliveInterval = receptionOptions.Value.KeepAliveInterval,

            };

            foreach (string origin in receptionOptions.Value.AllowedOrigins)
            {
                webSocketOptions.AllowedOrigins.Add(origin);
            }

            builder.Application.UseWebSockets(webSocketOptions);

            return builder;
        }

        private static void EnsureServicesConfigured<TMarker>(IServiceProvider serviceProvider)
        {
            MarkerService<TMarker>? markerService = serviceProvider.GetService<MarkerService<TMarker>>();

            if (markerService is null)
            {
                throw new InvalidOperationException(
                    "Unable to use Web Socket Reception: required services not found. " +
                    "Please add all the required services by calling " +
                    $"IServiceCollection.AddBitfluxHub<>(...).AddWebSocketReception(...)\" " +
                    "inside the \"ConfigureServices(...)\" call " +
                    "in the application startup code");
            }
        }
    }
}
