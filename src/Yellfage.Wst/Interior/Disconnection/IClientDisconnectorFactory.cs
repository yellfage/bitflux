using System.Net.WebSockets;

namespace Yellfage.Wst.Interior.Disconnection
{
    internal interface IClientDisconnectorFactory
    {
        IClientDisconnector Create(WebSocket webSocket);
    }
}
