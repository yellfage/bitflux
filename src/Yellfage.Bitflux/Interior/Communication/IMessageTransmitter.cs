using System.Threading;
using System.Threading.Tasks;

using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal interface IMessageTransmitter<TMarker>
    {
        Task TransmitAsync(OutgoingMessage message, CancellationToken cancellationToken = default);
    }
}
