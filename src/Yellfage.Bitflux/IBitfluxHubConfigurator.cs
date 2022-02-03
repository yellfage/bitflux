using Microsoft.Extensions.DependencyInjection;

using Yellfage.Bitflux.Bussing;
using Yellfage.Bitflux.Caching;
using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux
{
    public interface IBitfluxHubConfigurator<TMarker>
    {
        IServiceCollection Services { get; }

        IBitfluxHubConfigurator<TMarker> AddBus<TBus>() where TBus : class, IBus<TMarker>;
        IBitfluxHubConfigurator<TMarker> AddReception<TReception>() where TReception : class, IReception<TMarker>;
        IBitfluxHubConfigurator<TMarker> AddProtocol<TProtocol>() where TProtocol : class, IProtocol<TMarker>;
        IBitfluxHubConfigurator<TMarker> AddCache<TCache>() where TCache : class, IHubCache<TMarker>;
        IBitfluxHubConfigurator<TMarker> AddClientCache<TFactory>() where TFactory : class, IClientCacheFactory<TMarker>;
    }
}
