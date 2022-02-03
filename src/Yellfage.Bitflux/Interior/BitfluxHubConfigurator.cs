using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using Yellfage.Bitflux.Bussing;
using Yellfage.Bitflux.Caching;
using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior
{
    internal class BitfluxHubConfigurator<TMarker> : IBitfluxHubConfigurator<TMarker>
    {
        public IServiceCollection Services { get; }

        public BitfluxHubConfigurator(IServiceCollection services)
        {
            Services = services;
        }

        public IBitfluxHubConfigurator<TMarker> AddBus<TBus>() where TBus : class, IBus<TMarker>
        {
            Services.AddSingleton<IBus<TMarker>, TBus>();

            return this;
        }

        public IBitfluxHubConfigurator<TMarker> AddReception<TReception>()
            where TReception : class, IReception<TMarker>
        {
            Services.TryAddEnumerable(ServiceDescriptor.Singleton<IReception<TMarker>, TReception>());

            return this;
        }

        public IBitfluxHubConfigurator<TMarker> AddProtocol<TProtocol>()
            where TProtocol : class, IProtocol<TMarker>
        {
            Services.TryAddEnumerable(ServiceDescriptor.Singleton<IProtocol<TMarker>, TProtocol>());

            return this;
        }

        public IBitfluxHubConfigurator<TMarker> AddCache<TCache>()
            where TCache : class, IHubCache<TMarker>
        {
            Services.AddSingleton<IHubCache<TMarker>, TCache>();

            return this;
        }

        public IBitfluxHubConfigurator<TMarker> AddClientCache<TFactory>()
            where TFactory : class, IClientCacheFactory<TMarker>
        {
            Services.AddSingleton<IClientCacheFactory<TMarker>, TFactory>();

            return this;
        }
    }
}
