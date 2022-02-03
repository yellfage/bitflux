using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal class MessageTransmitterFactory<TMarker> : IMessageTransmitterFactory<TMarker>
    {
        public IMessageTransmitter<TMarker> Create(ITransport<TMarker> transport, IProtocol<TMarker> protocol)
        {
            return new MessageTransmitter<TMarker>(transport, protocol);
        }
    }
}
