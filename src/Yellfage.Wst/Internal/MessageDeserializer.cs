using System;
using System.Diagnostics.CodeAnalysis;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Internal
{
    internal class MessageDeserializer : IMessageDeserializer
    {
        private IProtocol Protocol { get; }
        private IMessageTypeResolver MessageTypeResolver { get; }

        public MessageDeserializer(IProtocol protocol, IMessageTypeResolver messageTypeResolver)
        {
            Protocol = protocol;
            MessageTypeResolver = messageTypeResolver;
        }

        public bool TryDeserialize(ArraySegment<byte> bytes, [MaybeNullWhen(false)] out IncomingMessage message)
        {
            try
            {
                message = Protocol.Deserialize(bytes, MessageTypeResolver);
            }
            catch
            {
                message = null;
            }

            return message is not null;
        }
    }
}
