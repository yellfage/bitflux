using System.Net.WebSockets;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Receptions.WebSockets
{
    internal class Reception<TMarker> : IReception<TMarker>
    {
        public string TransportName { get; } = "web-socket";

        private ITransportFactory<TMarker> TransportFactory { get; }

        public Reception(ITransportFactory<TMarker> transportFactory)
        {
            TransportFactory = transportFactory;
        }

        public async Task<ITransport<TMarker>> AcceptAsync(HttpContext context)
        {
            if (!context.WebSockets.IsWebSocketRequest)
            {
                throw new ReceptionException(
                    "Unable to accept the request: " +
                    "it is not a WebSocket establishment request");
            }

            WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();

            return TransportFactory.Create(webSocket);
        }
    }
}
