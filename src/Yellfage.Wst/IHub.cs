using Yellfage.Wst.Caching;

namespace Yellfage.Wst
{
    public interface IHub<TMarker>
    {
        IClientManager<TMarker> Clients { get; }
        IGroupManager<TMarker> Groups { get; }
        IHubCache<TMarker> Cache { get; }
    }
}
