using System;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace Yellfage.Wst.Internal
{
    internal interface IMessageReceiver
    {
        Task StartReceivingAsync(WebSocket webSocket, Func<ArraySegment<byte>, Task> processMessageBytesAsync);
    }
}
