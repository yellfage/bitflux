using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Receptions.WebSockets
{
    internal class Transport<TMarker> : ITransport<TMarker>
    {
        private WebSocket WebSocket { get; }
        private IMessageReceiver<TMarker> MessageReceiver { get; }

        public Transport(WebSocket webSocket, IMessageReceiver<TMarker> messageReceiver)
        {
            WebSocket = webSocket;
            MessageReceiver = messageReceiver;
        }

        public async Task StartAsync(Func<ArraySegment<byte>, Task> processBytesAsync)
        {
            await MessageReceiver.StartAsync(WebSocket, processBytesAsync);
        }

        public async Task StopAsync(string reason, CancellationToken cancellationToken)
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

        public async Task SendAsync(
            ArraySegment<byte> buffer,
            TransferFormat transferFormat,
            CancellationToken cancellationToken)
        {
            if (WebSocket.State != WebSocketState.Open)
            {
                return;
            }

            await WebSocket.SendAsync(
                buffer,
                (WebSocketMessageType)transferFormat,
                true,
                cancellationToken);
        }

        public void Dispose()
        {
            WebSocket.Dispose();
        }
    }
}
