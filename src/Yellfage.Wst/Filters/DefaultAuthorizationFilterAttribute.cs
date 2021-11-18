using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Yellfage.Wst.Filters
{
    public abstract class DefaultAuthorizationFilterAttribute : Attribute, IFilter, IAuthorizeData
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

        public async Task<object?> ApplyAsync<TMarker>(
            IInvocationContext<TMarker> context,
            Func<Task<object?>> next)
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
                return await OnFailureAsync(context, authorizationResult);
            }

            return await next.Invoke();
        }

        public virtual Task<object?> OnFailureAsync<TMarker>(
            IInvocationContext<TMarker> context,
            AuthorizationResult authorizationResult)
        {
            throw new InvocationException(
                $"Failed to invoke the '{context.HandlerName}' handler: authorization failed");
        }
    }
}
