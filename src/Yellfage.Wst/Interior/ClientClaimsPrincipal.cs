using System.Security.Claims;

namespace Yellfage.Wst.Interior
{
    internal class ClientClaimsPrincipal : IClientClaimsPrincipal
    {
        public ClaimsPrincipal Current { get; set; }

        public ClientClaimsPrincipal(ClaimsPrincipal current)
        {
            Current = current;
        }
    }
}
