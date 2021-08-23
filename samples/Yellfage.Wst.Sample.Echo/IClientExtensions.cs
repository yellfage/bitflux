using System;
using System.Security.Claims;
using System.Collections.Generic;

namespace Yellfage.Wst.Sample.Echo
{
    public static class IClientExtensions
    {
        // The next authentication method is not the best for production
        // Consider others methods, such as tickets or use the schemes provided by ASP.NET
        // Read more about the ticket-based authentication method here:
        // https://www.neuralegion.com/blog/websocket-security-top-vulnerabilities/#ticket-based-authentication
        public static void Authenticate(this IClient<EchoHub> client, int userId)
        {
            if (client.IsAuthenticated())
            {
                return;
            }

            var identity = new ClaimsIdentity(
                new List<Claim>()
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, userId.ToString())
                },
                "authentication-type",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            client.User.Current = new(identity);
        }

        public static bool IsAuthenticated(this IClient<EchoHub> client)
        {
            return client.User.Current.Identity?.IsAuthenticated ?? false;
        }

        public static int GetUserId(this IClient<EchoHub> client)
        {
            if (!IsAuthenticated(client))
            {
                throw new InvalidOperationException(
                    $"The client with '{client.Id}' id is not authenticated");
            }

            string id = client.User.Current.FindFirstValue(ClaimsIdentity.DefaultNameClaimType);

            return Convert.ToInt32(id);
        }
    }
}
