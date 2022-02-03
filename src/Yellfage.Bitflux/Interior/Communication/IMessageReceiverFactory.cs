using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal interface IMessageReceiverFactory<TMarker>
    {
        IMessageReceiver<TMarker> Create(ITransport<TMarker> transport, IMessageDeserializer<TMarker> messageDeserializer);
    }
}
