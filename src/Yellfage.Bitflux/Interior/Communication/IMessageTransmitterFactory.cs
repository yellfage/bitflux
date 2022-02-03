
using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal interface IMessageTransmitterFactory<TMarker>
    {
        IMessageTransmitter<TMarker> Create(ITransport<TMarker> transport, IProtocol<TMarker> protocol);
    }
}
