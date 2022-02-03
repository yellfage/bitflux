using System;
using System.Threading.Tasks;

using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal interface IMessageReceiver<TMarker>
    {
        Task StartAsync(Func<IncomingMessage, Task> messageHandler);
    }
}
