using System.Security.Claims;

namespace Yellfage.Bitflux.Interior
{
    internal interface IClientClaimsPrincipalFactory<TMarker>
    {
        IClientClaimsPrincipal<TMarker> Create(ClaimsPrincipal user);
    }
}
