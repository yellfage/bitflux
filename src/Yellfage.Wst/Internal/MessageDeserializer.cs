using System;
using System.Diagnostics.CodeAnalysis;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Internal
{
    internal class MessageDeserializer : IMessageDeserializer
    {
        private IProtocol Protocol { get; }

        public MessageDeserializer(IProtocol protocol)
        {
            Protocol = protocol;
        }

        public bool TryDeserialize(ArraySegment<byte> bytes, [MaybeNullWhen(false)] out IncomingMessage message)
        {
            return Protocol.TryDeserialize(bytes, out message);
        }
    }
}
