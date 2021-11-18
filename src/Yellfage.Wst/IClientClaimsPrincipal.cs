using System.Security.Claims;

namespace Yellfage.Wst
{
    public interface IClientClaimsPrincipal<TMarker>
    {
        ClaimsPrincipal Current { get; set; }
    }
}
