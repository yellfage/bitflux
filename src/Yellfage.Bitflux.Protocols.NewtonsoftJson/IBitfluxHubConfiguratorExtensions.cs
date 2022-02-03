using System;

using Microsoft.Extensions.DependencyInjection;

namespace Yellfage.Bitflux.Protocols.NewtonsoftJson
{
    public static class IBitfluxHubConfiguratorExtensions
    {
        public static IBitfluxHubConfigurator<TMarker> AddNewtonsoftJsonProtocol<TMarker>(
            this IBitfluxHubConfigurator<TMarker> builder)
        {
            return builder.AddNewtonsoftJsonProtocol(_ => { });
        }

        public static IBitfluxHubConfigurator<TMarker> AddNewtonsoftJsonProtocol<TMarker>(
            this IBitfluxHubConfigurator<TMarker> builder,
            Action<NewtonsoftJsonProtocolOptions> configure)
        {
            builder.AddProtocol<NewtonsoftJsonProtocol<TMarker>>();

            builder.Services.Configure(configure);

            return builder;
        }
    }
}
