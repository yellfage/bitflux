using System;
using System.Diagnostics.CodeAnalysis;

using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal interface IMessageDeserializer<TMarker>
    {
        bool TryDeserialize(ArraySegment<byte> bytes, [MaybeNullWhen(false)] out IncomingMessage message);
    }
}
