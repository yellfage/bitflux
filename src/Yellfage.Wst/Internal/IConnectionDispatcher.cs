using System.Net.WebSockets;
using System.Threading.Tasks;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Internal
{
    internal interface IConnectionDispatcher
    {
        Task AcceptAsync(IProtocol protocol, WebSocket webSocket);
    }
}
