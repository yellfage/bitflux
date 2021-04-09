using System.Threading;
using System.Threading.Tasks;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Internal
{
    internal interface IMessageTransmitter
    {
        Task TransmitAsync(OutgoingMessage message, CancellationToken cancellationToken);
    }
}
