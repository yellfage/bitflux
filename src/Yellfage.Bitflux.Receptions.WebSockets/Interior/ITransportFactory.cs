using System.Net.WebSockets;

using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Receptions.WebSockets
{
    internal interface ITransportFactory<TMarker>
    {
        ITransport<TMarker> Create(WebSocket webSocket);
    }
}
