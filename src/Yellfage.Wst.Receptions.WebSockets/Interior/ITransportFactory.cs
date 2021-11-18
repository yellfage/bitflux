using System.Net.WebSockets;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Receptions.WebSockets
{
    internal interface ITransportFactory<TMarker>
    {
        ITransport<TMarker> Create(WebSocket webSocket);
    }
}
