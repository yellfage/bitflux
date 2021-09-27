using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Yellfage.Wst.Interior
{
    internal static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseHubWebSocket<TMarker>(
            this IApplicationBuilder builder)
        {
            IOptions<HubOptions<TMarker>> hubOptions = builder
                .ApplicationServices
                .GetRequiredService<IOptions<HubOptions<TMarker>>>();

            var webSocketOptions = new WebSocketOptions()
            {
                KeepAliveInterval = hubOptions.Value.Communication.KeepAliveInterval,

            };

            foreach (string origin in hubOptions.Value.Communication.AllowedOrigins)
            {
                webSocketOptions.AllowedOrigins.Add(origin);
            }

            return builder.UseWebSockets(webSocketOptions);
        }

        public static IApplicationBuilder UseWebSocketOnlyRestriction(
            this IApplicationBuilder builder)
        {
            return builder.Use((context, next) =>
             {
                 if (!context.WebSockets.IsWebSocketRequest)
                 {
                     context.Response.StatusCode = StatusCodes.Status404NotFound;

                     return Task.CompletedTask;
                 }

                 return next();
             });
        }

        public static IApplicationBuilder UseWebSocketAcceptance<TMarker>(
            this IApplicationBuilder builder)
        {
            return builder.Use((context, _) => builder
                .ApplicationServices
                .GetRequiredService<IRequestProcessor>()
                .ProcessAsync<TMarker>(context));
        }
    }
}
