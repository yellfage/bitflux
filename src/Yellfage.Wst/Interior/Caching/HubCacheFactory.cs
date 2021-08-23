using Yellfage.Wst.Caching;

namespace Yellfage.Wst.Interior.Caching
{
    internal class HubCacheFactory : IHubCacheFactory
    {
        public IHubCache<TMarker> Create<TMarker>()
        {
            return new HubCache<TMarker>();
        }
    }
}
