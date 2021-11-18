using Microsoft.Extensions.DependencyInjection;

using Yellfage.Wst.Bussing;
using Yellfage.Wst.Caching;
using Yellfage.Wst.Communication;

namespace Yellfage.Wst
{
    public interface IWstHubConfigurator<TMarker>
    {
        IServiceCollection Services { get; }

        IWstHubConfigurator<TMarker> AddBus<TBus>() where TBus : class, IBus<TMarker>;
        IWstHubConfigurator<TMarker> AddReception<TReception>() where TReception : class, IReception<TMarker>;
        IWstHubConfigurator<TMarker> AddProtocol<TProtocol>() where TProtocol : class, IProtocol<TMarker>;
        IWstHubConfigurator<TMarker> AddCache<TCache>() where TCache : class, IHubCache<TMarker>;
        IWstHubConfigurator<TMarker> AddClientCache<TFactory>() where TFactory : class, IClientCacheFactory<TMarker>;
    }
}
