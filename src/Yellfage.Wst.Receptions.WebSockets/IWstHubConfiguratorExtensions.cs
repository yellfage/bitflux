using System;

using Microsoft.Extensions.DependencyInjection;

namespace Yellfage.Wst.Receptions.WebSockets
{
    public static class IWstHubConfiguratorExtensions
    {
        public static IWstHubConfigurator<TMarker> AddWebSocketReception<TMarker>(
            this IWstHubConfigurator<TMarker> builder)
        {
            return AddWebSocketReception(builder, _ => { });
        }

        public static IWstHubConfigurator<TMarker> AddWebSocketReception<TMarker>(
            this IWstHubConfigurator<TMarker> builder,
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
