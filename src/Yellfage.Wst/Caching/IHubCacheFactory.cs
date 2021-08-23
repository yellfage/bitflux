namespace Yellfage.Wst.Caching
{
    public interface IHubCacheFactory
    {
        IHubCache<TMarker> Create<TMarker>();
    }
}
