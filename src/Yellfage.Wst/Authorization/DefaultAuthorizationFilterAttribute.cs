using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Yellfage.Wst.Authorization
{
    public class DefaultAuthorizationFilterAttribute : AbstractAuthorizationFilterAttribute, IAuthorizeData
    {
        public string? Policy { get; set; }
        public string? Roles { get; set; }
        public string? AuthenticationSchemes { get; set; }

        public DefaultAuthorizationFilterAttribute()
        {
        }

        public DefaultAuthorizationFilterAttribute(string policy)
        {
            Policy = policy;
        }

        public override async Task ApplyAsync<TMarker>(
            IInvocationExecutionContext<TMarker> context,
            Func<Task> next)
        {
            IAuthorizationPolicyProvider authorizationPolicyProvider = context
                .ServiceProvider
                .GetRequiredService<IAuthorizationPolicyProvider>();

            IAuthorizationService authorizationService = context
                .ServiceProvider
                .GetRequiredService<IAuthorizationService>();

            AuthorizationPolicy authorizationPolicy = ( await AuthorizationPolicy
                .CombineAsync(authorizationPolicyProvider, new[] { this }) )!;

            AuthorizationResult authorizationResult = await authorizationService
                .AuthorizeAsync(context.Client.User.Current, context, authorizationPolicy);

            if (!authorizationResult.Succeeded)
            {
                await OnFailureAsync(context, authorizationResult);

                return;
            }

            await next();
        }

        public virtual Task OnFailureAsync<TMarker>(
            IInvocationExecutionContext<TMarker> context,
            AuthorizationResult authorizationResult)
        {
            return context.ReplyErrorAsync(
                $"Failed to invoke the '{context.HandlerName}' handler: authorization failed");
        }
    }
}
