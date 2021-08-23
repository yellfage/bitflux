using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

using Yellfage.Wst.Authorization;

namespace Yellfage.Wst.Sample.Echo
{
    public class AuthorizationFilterAttribute : DefaultAuthorizationFilterAttribute
    {
        public override Task OnAuthorizationFailedAsync<TMarker>(
            IInvocationContext<TMarker> context,
            AuthorizationResult authorizationResult)
        {
            // Handle the authorization failure in your own way

            return base.OnAuthorizationFailedAsync(context, authorizationResult);
        }
    }
}
