using System;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace Yellfage.Wst.Receptions.WebSockets
{
    internal interface IMessageReceiver<TMarker>
    {
        Task StartAsync(WebSocket webSocket, Func<ArraySegment<byte>, Task> processBytesAsync);
    }
}
