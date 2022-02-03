using System;

using Microsoft.Extensions.DependencyInjection;

namespace Yellfage.Bitflux.Receptions.WebSockets
{
    public static class IBitfluxHubConfiguratorExtensions
    {
        public static IBitfluxHubConfigurator<TMarker> AddWebSocketReception<TMarker>(
            this IBitfluxHubConfigurator<TMarker> builder)
        {
            return AddWebSocketReception(builder, _ => { });
        }

        public static IBitfluxHubConfigurator<TMarker> AddWebSocketReception<TMarker>(
            this IBitfluxHubConfigurator<TMarker> builder,
            Action<WebSocketReceptionOptions<TMarker>> configure)
        {
            builder.Services.AddSingleton<MarkerService<TMarker>>();

            builder.Services.AddSingleton<ITransportFactory<TMarker>, TransportFactory<TMarker>>();
            builder.Services.AddSingleton<IMessageReceiver<TMarker>, MessageReceiver<TMarker>>();

            builder.AddReception<Reception<TMarker>>();

            builder.Services.Configure(configure);

            return builder;
        }
    }
}
