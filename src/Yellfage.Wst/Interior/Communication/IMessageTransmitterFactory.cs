using System.Net.WebSockets;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IMessageTransmitterFactory
    {
        IMessageTransmitter Create(WebSocket webSocket, IProtocol protocol);
    }
}
