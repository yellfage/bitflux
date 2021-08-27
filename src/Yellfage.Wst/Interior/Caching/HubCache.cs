using Yellfage.Wst.Caching;

namespace Yellfage.Wst.Interior.Caching
{
    internal class HubCache<TMarker> : Cache, IHubCache<TMarker>
    {
        public HubCache(IHubCacheConverter hubCacheConverter) : base(hubCacheConverter)
        {
        }
    }
}
