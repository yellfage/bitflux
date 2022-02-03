using System.Security.Claims;

namespace Yellfage.Bitflux.Interior
{
    internal class ClientClaimsPrincipalFactory<TMarker> : IClientClaimsPrincipalFactory<TMarker>
    {
        public IClientClaimsPrincipal<TMarker> Create(ClaimsPrincipal user)
        {
            return new ClientClaimsPrincipal<TMarker>(user);
        }
    }
}
