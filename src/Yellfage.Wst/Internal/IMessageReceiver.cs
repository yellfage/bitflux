using System;
using System.Threading.Tasks;

namespace Yellfage.Wst.Internal
{
    internal interface IMessageReceiver
    {
        Task StartReceivingAsync(Func<ArraySegment<byte>, Task> processMessageBytesAsync);
    }
}
