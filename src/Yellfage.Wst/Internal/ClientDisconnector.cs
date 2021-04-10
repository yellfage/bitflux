using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace Yellfage.Wst.Internal
{
    class ClientDisconnector : IClientDisconnector
    {
        private WebSocket WebSocket { get; }

        public ClientDisconnector(WebSocket webSocket)
        {
            WebSocket = webSocket;
        }

        public async Task DisconnectAsync(
            string reason,
            CancellationToken cancellationToken = default)
        {
            if (WebSocket.State != WebSocketState.Open)
            {
                return;
            }

            await WebSocket.CloseOutputAsync(
                WebSocketCloseStatus.NormalClosure,
                reason,
                cancellationToken);
        }
    }
}
