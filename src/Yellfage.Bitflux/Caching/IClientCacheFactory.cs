namespace Yellfage.Bitflux.Caching
{
    public interface IClientCacheFactory<TMarker>
    {
        IClientCache<TMarker> Create(IClientClaimsPrincipal<TMarker> user);
    }
}
