using Yellfage.Wst.Caching;

namespace Yellfage.Wst.Interior.Caching
{
    internal class ClientCache<TMarker> : Cache, IClientCache<TMarker>
    {
        public ClientCache(IClientCacheConverter clientCacheConverter) : base(clientCacheConverter)
        {
        }
    }
}
