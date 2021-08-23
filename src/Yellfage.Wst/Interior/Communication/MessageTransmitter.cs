using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal class MessageTransmitter : IMessageTransmitter
    {
        private WebSocket WebSocket { get; }
        private IProtocol Protocol { get; }

        public MessageTransmitter(WebSocket webSocket, IProtocol protocol)
        {
            WebSocket = webSocket;
            Protocol = protocol;
        }

        public async Task TransmitAsync(OutgoingMessage message, CancellationToken cancellationToken)
        {
            if (WebSocket.State != WebSocketState.Open)
            {
                return;
            }

            await WebSocket.SendAsync(
                Protocol.Serialize(message),
                (WebSocketMessageType)Protocol.TransferFormat,
                true,
                cancellationToken);
        }
    }
}
