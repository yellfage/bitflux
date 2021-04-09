using System.Net.WebSockets;
using System.Threading.Tasks;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Internal
{
    internal interface IMessageDispatcher<T>
    {
        Task StartAcceptingAsync(WebSocket webSocket, IProtocol protocol, IClient<T> client);
    }
}
