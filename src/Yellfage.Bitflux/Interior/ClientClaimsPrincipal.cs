using System.Security.Claims;

namespace Yellfage.Bitflux.Interior
{
    internal class ClientClaimsPrincipal<TMarker> : IClientClaimsPrincipal<TMarker>
    {
        public ClaimsPrincipal Current { get; set; }

        public ClientClaimsPrincipal(ClaimsPrincipal current)
        {
            Current = current;
        }
    }
}
