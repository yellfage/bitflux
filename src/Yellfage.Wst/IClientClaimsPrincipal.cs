using System.Security.Claims;

namespace Yellfage.Wst
{
    public interface IClientClaimsPrincipal
    {
        ClaimsPrincipal Current { get; set; }
    }
}
