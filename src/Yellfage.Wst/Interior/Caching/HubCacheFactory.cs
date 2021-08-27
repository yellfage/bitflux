using Yellfage.Wst.Caching;

namespace Yellfage.Wst.Interior.Caching
{
    internal class HubCacheFactory : IHubCacheFactory
    {
        private IHubCacheConverter HubCacheConverter { get; }

        public HubCacheFactory(IHubCacheConverter hubCacheConverter)
        {
            HubCacheConverter = hubCacheConverter;
        }

        public IHubCache<TMarker> Create<TMarker>()
        {
            return new HubCache<TMarker>(HubCacheConverter);
        }
    }
}
