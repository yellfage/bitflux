using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal class MessageDeserializerFactory<TMarker> : IMessageDeserializerFactory<TMarker>
    {
        private IMessageTypeResolver<TMarker> MessageTypeResolver { get; }

        public MessageDeserializerFactory(IMessageTypeResolver<TMarker> messageTypeResolver)
        {
            MessageTypeResolver = messageTypeResolver;
        }

        public IMessageDeserializer<TMarker> Create(IProtocol<TMarker> protocol)
        {
            return new MessageDeserializer<TMarker>(protocol, MessageTypeResolver);
        }
    }
}
