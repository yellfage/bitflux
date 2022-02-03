
using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior.Communication
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
