using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Yellfage.Wst.Communication.Protocol.NewtonsoftJson
{
    public static class IWstServerBuilderExtensions
    {
        public static IWstServerBuilder AddNewtonsoftJsonProtocol(
            this IWstServerBuilder builder)
        {
            return builder.AddNewtonsoftJsonProtocol(_ => { });
        }

        public static IWstServerBuilder AddNewtonsoftJsonProtocol(
            this IWstServerBuilder builder,
            Action<NewtonsoftJsonProtocolOptions> configure)
        {
            builder.Services.TryAddEnumerable(
                ServiceDescriptor.Singleton<IProtocol, NewtonsoftJsonProtocol>());

            builder.Services.Configure(configure);

            return builder;
        }
    }
}
