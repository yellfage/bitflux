using System;
using System.Linq;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Yellfage.Wst.Bussing;
using Yellfage.Wst.Caching;
using Yellfage.Wst.Communication;
using Yellfage.Wst.Communication.Protocol.NewtonsoftJson;
using Yellfage.Wst.Interior;
using Yellfage.Wst.Interior.Bussing;
using Yellfage.Wst.Interior.Caching;
using Yellfage.Wst.Interior.Communication;
using Yellfage.Wst.Interior.Connection;
using Yellfage.Wst.Interior.Disconnection;
using Yellfage.Wst.Interior.Filtration;
using Yellfage.Wst.Interior.Handling;
using Yellfage.Wst.Interior.Invocation;
using Yellfage.Wst.Interior.Mapping;

namespace Yellfage.Wst
{
    public static class IServiceCollectionExtensions
    {
        public static IWstServerBuilder AddWst(this IServiceCollection services)
        {
            AddServices(services);
            AddHubs(services);
            AddWorkers(services);

            var builder = new WstServerBuilder(services);

            builder.AddNewtonsoftJsonProtocol();

            return builder;
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddSingleton<WstMarkerService>();
            services.AddSingleton<IProtocolProvider, ProtocolProvider>();
            services.AddSingleton<IHubCacheConverter, CacheConverter>();
            services.AddSingleton<IClientCacheConverter, CacheConverter>();
            services.AddSingleton<IBusFactory, BusFactory>();
            services.AddSingleton<IClientManagerFactory, ClientManagerFactory>();
            services.AddSingleton<IGroupManagerFactory, GroupManagerFactory>();
            services.AddSingleton<IHubCacheFactory, HubCacheFactory>();
            services.AddSingleton<IClientCacheFactory, ClientCacheFactory>();

            services.AddScoped<IFilterScreener, FilterScreener>();
            services.AddScoped<IFilterExplorer, FilterExplorer>();
            services.AddScoped<IFilterExecutor, FilterExecutor>();
            services.AddScoped<IHubMapper, HubMapper>();
            services.AddScoped<IHubFilterStore, HubFilterStore>();
            services.AddScoped<IRequestProcessor, RequestProcessor>();
            services.AddScoped<IMessageTransmitterFactory, MessageTransmitterFactory>();
            services.AddScoped<IClientDisconnectorFactory, ClientDisconnectorFactory>();
            services.AddScoped<IClientFactory, ClientFactory>();
            services.AddScoped<IMessageDeserializerFactory, MessageDeserializerFactory>();
            services.AddScoped<IMessageTypeResolver, MessageTypeResolver>();
            services.AddScoped<IMessageReceiverFactory, MessageReceiverFactory>();
            services.AddScoped<IArgumentConverterFactory, ArgumentConverterFactory>();
            services.AddScoped<IMessageDispatcherFactory, MessageDispatcherFactory>();
            services.AddScoped<IInvocationProcessorFactory, InvocationProcessorFactory>();
            services.AddScoped<IHandlerStore, HandlerStore>();
            services.AddScoped<IHandlerFilterStore, HandlerFilterStore>();
            services.AddScoped<IConnectionProcessorFactory, ConnectionProcessorFactory>();
            services.AddScoped<IWorkerMapper, WorkerMapper>();
            services.AddScoped<IHandlerMapper, HandlerMapper>();
        }

        private static void AddHubs(IServiceCollection services)
        {
            Assembly assembly = Assembly.GetEntryAssembly()!;

            foreach (Type type in assembly.DefinedTypes)
            {
                if (typeof(Hub).IsAssignableFrom(type))
                {
                    Type hubInterfaceType = type.GetInterfaces().First();

                    Type markerType = hubInterfaceType.GetGenericArguments().First();

                    Type hubPostConfigureOptionsInterfaceType = typeof(IPostConfigureOptions<>)
                        .MakeGenericType(typeof(HubOptions<>).MakeGenericType(markerType));

                    Type hubPostConfigureOptionsType = typeof(HubPostConfigureOptions<>)
                        .MakeGenericType(markerType);

                    services.AddSingleton(hubPostConfigureOptionsInterfaceType, hubPostConfigureOptionsType);

                    services.AddSingleton(hubInterfaceType, type);
                }
            }
        }

        private static void AddWorkers(IServiceCollection services)
        {
            Assembly assembly = Assembly.GetEntryAssembly()!;

            foreach (Type type in assembly.DefinedTypes)
            {
                if (typeof(Worker).IsAssignableFrom(type))
                {
                    services.AddScoped(type);
                }
            }
        }
    }
}
