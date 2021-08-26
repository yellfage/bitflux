using System;

using Microsoft.Extensions.DependencyInjection;

namespace Yellfage.Wst
{
    public static class IWstServerBuilderExtensions
    {
        public static IWstServerBuilder AddHubOptions<TMarker>(
            this IWstServerBuilder builder, Action<HubOptions<TMarker>> configure)
        {
            var options = new HubOptions<TMarker>();

            configure(options);

            return AddHubOptions(builder, options);
        }

        public static IWstServerBuilder AddHubOptions<TMarker>(
            this IWstServerBuilder builder, HubOptions<TMarker> options)
        {
            builder.Services.AddSingleton(options);

            return builder;
        }
    }
}
