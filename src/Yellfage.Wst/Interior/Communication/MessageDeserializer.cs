using System;
using System.Diagnostics.CodeAnalysis;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal class MessageDeserializer<TMarker> : IMessageDeserializer<TMarker>
    {
        private IProtocol<TMarker> Protocol { get; }
        private IMessageTypeResolver<TMarker> MessageTypeResolver { get; }

        public MessageDeserializer(
            IProtocol<TMarker> protocol,
            IMessageTypeResolver<TMarker> messageTypeResolver)
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
