using Yellfage.Bitflux.Caching;

namespace Yellfage.Bitflux.Interior.Caching
{
    internal class ClientCacheFactory<TMarker> : IClientCacheFactory<TMarker>
    {
        public IClientCache<TMarker> Create(IClientClaimsPrincipal<TMarker> user)
        {
            return new ClientCache<TMarker>();
        }
    }
}
