using System;

using Microsoft.Extensions.DependencyInjection;

namespace Yellfage.Wst.Protocols.NewtonsoftJson
{
    public static class IWstHubConfiguratorExtensions
    {
        public static IWstHubConfigurator<TMarker> AddNewtonsoftJsonProtocol<TMarker>(
            this IWstHubConfigurator<TMarker> builder)
        {
            return builder.AddNewtonsoftJsonProtocol(_ => { });
        }

        public static IWstHubConfigurator<TMarker> AddNewtonsoftJsonProtocol<TMarker>(
            this IWstHubConfigurator<TMarker> builder,
            Action<NewtonsoftJsonProtocolOptions> configure)
        {
            builder.AddProtocol<NewtonsoftJsonProtocol<TMarker>>();

            builder.Services.Configure(configure);

            return builder;
        }
    }
}
