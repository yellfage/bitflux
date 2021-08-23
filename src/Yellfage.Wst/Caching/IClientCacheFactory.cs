namespace Yellfage.Wst.Caching
{
    public interface IClientCacheFactory
    {
        IClientCache<TMarker> Create<TMarker>(IClientClaimsPrincipal user);
    }
}
