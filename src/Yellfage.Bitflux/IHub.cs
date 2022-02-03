using Yellfage.Bitflux.Caching;

namespace Yellfage.Bitflux
{
    public interface IHub<TMarker>
    {
        IClientManager<TMarker> Clients { get; }
        IGroupManager<TMarker> Groups { get; }
        IHubCache<TMarker> Cache { get; }
    }
}
