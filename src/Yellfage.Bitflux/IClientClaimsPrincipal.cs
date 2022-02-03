using System.Security.Claims;

namespace Yellfage.Bitflux
{
    public interface IClientClaimsPrincipal<TMarker>
    {
        ClaimsPrincipal Current { get; set; }
    }
}
