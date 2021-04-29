using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AuthorizationFilterAttribute : Attribute, IInvocationFilter, IAuthorizeData
    {
        public string? Policy { get; set; }
        public string? Roles { get; set; }
        public string? AuthenticationSchemes { get; set; }

        public int Priority => 1;

        public AuthorizationFilterAttribute()
        {
        }

        public AuthorizationFilterAttribute(string policy)
        {
            Policy = policy;
        }

        public async Task ApplyAsync<T>(IInvocationContext<T> context, Func<Task> next)
        {
            IAuthorizationPolicyProvider authorizationPolicyProvider = context
                .ServiceProvider
                .GetRequiredService<IAuthorizationPolicyProvider>();

            IAuthorizationService authorizationService = context
                .ServiceProvider
                .GetRequiredService<IAuthorizationService>();

            AuthorizationPolicy authorizePolicy = ( await AuthorizationPolicy
                .CombineAsync(authorizationPolicyProvider, new[] { this }) )!;

            AuthorizationResult authorizationResult = await authorizationService.AuthorizeAsync(
                context.Caller.HttpContext.User, context, authorizePolicy);

            if (!authorizationResult.Succeeded)
            {
                await OnAuthorizationFailed(context, authorizationResult);

                return;
            }

            await next();
        }

        public virtual Task OnAuthorizationFailed<T>(
            IInvocationContext<T> context,
            AuthorizationResult authorizationResult)
        {
            return context.ReplyErrorAsync($"Failed to invoke '{context.HandlerName}' handler: authorization failed");
        }
    }
}
