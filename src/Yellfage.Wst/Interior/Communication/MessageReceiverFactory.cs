
using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal class MessageReceiverFactory<TMarker> : IMessageReceiverFactory<TMarker>
    {
        public IMessageReceiver<TMarker> Create(
            ITransport<TMarker> transport,
            IMessageDeserializer<TMarker> messageDeserializer)
        {
            return new MessageReceiver<TMarker>(transport, messageDeserializer);
        }
    }
}
