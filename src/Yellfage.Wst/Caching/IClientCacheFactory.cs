namespace Yellfage.Wst.Caching
{
    public interface IClientCacheFactory<TMarker>
    {
        IClientCache<TMarker> Create(IClientClaimsPrincipal<TMarker> user);
    }
}
