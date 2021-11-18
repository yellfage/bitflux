using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal class MessageTransmitterFactory<TMarker> : IMessageTransmitterFactory<TMarker>
    {
        public IMessageTransmitter<TMarker> Create(ITransport<TMarker> transport, IProtocol<TMarker> protocol)
        {
            return new MessageTransmitter<TMarker>(transport, protocol);
        }
    }
}
