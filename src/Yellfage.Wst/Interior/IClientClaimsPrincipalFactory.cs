using System.Security.Claims;

namespace Yellfage.Wst.Interior
{
    internal interface IClientClaimsPrincipalFactory<TMarker>
    {
        IClientClaimsPrincipal<TMarker> Create(ClaimsPrincipal user);
    }
}
