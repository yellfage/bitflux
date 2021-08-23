using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal class MessageDeserializerFactory : IMessageDeserializerFactory
    {
        private IMessageTypeResolver MessageTypeResolver { get; }

        public MessageDeserializerFactory(IMessageTypeResolver messageTypeResolver)
        {
            MessageTypeResolver = messageTypeResolver;
        }

        public IMessageDeserializer Create(IProtocol protocol)
        {
            return new MessageDeserializer(protocol, MessageTypeResolver);
        }
    }
}
