using System.Net.WebSockets;

namespace Yellfage.Wst.Interior.Disconnection
{
    internal class ClientDisconnectorFactory : IClientDisconnectorFactory
    {
        public IClientDisconnector Create(WebSocket webSocket)
        {
            return new ClientDisconnector(webSocket);
        }
    }
}
