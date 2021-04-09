using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using Yellfage.Wst.Communication;
using Yellfage.Wst.Communication.Internal;

namespace Yellfage.Wst.Internal
{
    internal class RequestProcessor : IRequestProcessor
    {
        private IProtocolProvider ProtocolProvider { get; }
        private IConnectionDispatcher ConnectionDispatcher { get; }

        public RequestProcessor(
            IProtocolProvider protocolProvider,
            IConnectionDispatcher connectionDispatcher)
        {
            ProtocolProvider = protocolProvider;
            ConnectionDispatcher = connectionDispatcher;
        }

        public async Task ProcessAsync(HttpContext context, Func<Task> _)
        {
            if (!context.WebSockets.IsWebSocketRequest)
            {
                context.Response.StatusCode = StatusCodes.Status200OK;

                return;
            }

            if (ProtocolProvider.TryGet(
                context.WebSockets.WebSocketRequestedProtocols,
                out IProtocol? protocol))
            {
                WebSocket webSocket = await context
                    .WebSockets
                    .AcceptWebSocketAsync(protocol.Name);

                await ConnectionDispatcher.AcceptAsync(protocol, webSocket);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;

                return;
            }
        }
    }
}
