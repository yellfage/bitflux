using System;
using System.Threading.Tasks;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IMessageReceiver<TMarker>
    {
        Task StartAsync(Func<IncomingMessage, Task> messageHandler);
    }
}
