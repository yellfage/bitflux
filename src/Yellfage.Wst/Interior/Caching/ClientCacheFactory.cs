using Yellfage.Wst.Caching;

namespace Yellfage.Wst.Interior.Caching
{
    internal class ClientCacheFactory : IClientCacheFactory
    {
        public IClientCache<TMarker> Create<TMarker>(IClientClaimsPrincipal user)
        {
            return new ClientCache<TMarker>();
        }
    }
}
