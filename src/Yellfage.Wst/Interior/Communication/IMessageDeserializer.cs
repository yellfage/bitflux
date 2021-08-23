using System;
using System.Diagnostics.CodeAnalysis;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IMessageDeserializer
    {
        bool TryDeserialize(ArraySegment<byte> bytes, [MaybeNullWhen(false)] out IncomingMessage message);
    }
}
