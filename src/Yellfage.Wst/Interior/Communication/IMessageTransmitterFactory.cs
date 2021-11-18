
using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IMessageTransmitterFactory<TMarker>
    {
        IMessageTransmitter<TMarker> Create(ITransport<TMarker> transport, IProtocol<TMarker> protocol);
    }
}
