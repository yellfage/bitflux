using System.Net.WebSockets;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Receptions.WebSockets
{
    internal class TransportFactory<TMarker> : ITransportFactory<TMarker>
    {
        private IMessageReceiver<TMarker> MessageReceiver { get; }

        public TransportFactory(IMessageReceiver<TMarker> messageReceiver)
        {
            MessageReceiver = messageReceiver;
        }

        public ITransport<TMarker> Create(WebSocket webSocket)
        {
            return new Transport<TMarker>(webSocket, MessageReceiver);
        }
    }
}
