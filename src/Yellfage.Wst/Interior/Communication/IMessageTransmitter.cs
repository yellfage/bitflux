using System.Threading;
using System.Threading.Tasks;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IMessageTransmitter<TMarker>
    {
        Task TransmitAsync(OutgoingMessage message, CancellationToken cancellationToken = default);
    }
}
