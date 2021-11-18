using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IMessageReceiverFactory<TMarker>
    {
        IMessageReceiver<TMarker> Create(ITransport<TMarker> transport, IMessageDeserializer<TMarker> messageDeserializer);
    }
}
