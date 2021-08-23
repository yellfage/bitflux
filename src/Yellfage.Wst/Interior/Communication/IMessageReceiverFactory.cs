using System.Net.WebSockets;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IMessageReceiverFactory
    {
        IMessageReceiver Create<TMarker>(WebSocket webSocket, IMessageDeserializer messageDeserializer);
    }
}
