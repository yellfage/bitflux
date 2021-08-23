using System;
using System.Threading.Tasks;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IMessageReceiver
    {
        Task StartReceivingAsync(Func<IncomingMessage, Task> processMessageAsync);
    }
}
