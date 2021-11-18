using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using Yellfage.Wst.Bussing;
using Yellfage.Wst.Caching;
using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior
{
    internal class WstHubConfigurator<TMarker> : IWstHubConfigurator<TMarker>
    {
        public IServiceCollection Services { get; }

        public WstHubConfigurator(IServiceCollection services)
        {
            Services = services;
        }

        public IWstHubConfigurator<TMarker> AddBus<TBus>() where TBus : class, IBus<TMarker>
        {
            Services.AddSingleton<IBus<TMarker>, TBus>();

            return this;
        }

        public IWstHubConfigurator<TMarker> AddReception<TReception>()
            where TReception : class, IReception<TMarker>
        {
            Services.TryAddEnumerable(ServiceDescriptor.Singleton<IReception<TMarker>, TReception>());

            return this;
        }

        public IWstHubConfigurator<TMarker> AddProtocol<TProtocol>()
            where TProtocol : class, IProtocol<TMarker>
        {
            Services.TryAddEnumerable(ServiceDescriptor.Singleton<IProtocol<TMarker>, TProtocol>());

            return this;
        }

        public IWstHubConfigurator<TMarker> AddCache<TCache>()
            where TCache : class, IHubCache<TMarker>
        {
            Services.AddSingleton<IHubCache<TMarker>, TCache>();

            return this;
        }

        public IWstHubConfigurator<TMarker> AddClientCache<TFactory>()
            where TFactory : class, IClientCacheFactory<TMarker>
        {
            Services.AddSingleton<IClientCacheFactory<TMarker>, TFactory>();

            return this;
        }
    }
}
