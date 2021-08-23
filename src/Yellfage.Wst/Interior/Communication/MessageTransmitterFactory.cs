using System.Net.WebSockets;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal class MessageTransmitterFactory : IMessageTransmitterFactory
    {
        public IMessageTransmitter Create(WebSocket webSocket, IProtocol protocol)
        {
            return new MessageTransmitter(webSocket, protocol);
        }
    }
}
