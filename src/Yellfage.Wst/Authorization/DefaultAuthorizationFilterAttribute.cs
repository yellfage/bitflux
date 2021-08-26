using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

using Yellfage.Wst.Filtration;

namespace Yellfage.Wst.Authorization
{
    public class DefaultAuthorizationFilterAttribute : AbstractAuthorizationFilterAttribute, IFilter, IAuthorizeData
    {
        public string? Policy { get; set; }
        public string? Roles { get; set; }
        public string? AuthenticationSchemes { get; set; }

        public virtual int Priority => FilterPriority.Authorization;

        public DefaultAuthorizationFilterAttribute()
        {
        }

        public DefaultAuthorizationFilterAttribute(string policy)
        {
            Policy = policy;
        }

        public virtual async Task ApplyAsync<TMarker>(
            IInvocationContext<TMarker> context,
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
            IInvocationContext<TMarker> context,
            AuthorizationResult authorizationResult)
        {
            return context.ReplyErrorAsync(
                $"Failed to invoke the '{context.HandlerName}' handler: authorization failed");
        }
    }
}
