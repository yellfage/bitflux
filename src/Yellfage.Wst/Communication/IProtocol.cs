using System;
using System.Diagnostics.CodeAnalysis;

namespace Yellfage.Wst.Communication
{
    public interface IProtocol
    {
        string Name { get; }
        TransferFormat TransferFormat { get; }

        ArraySegment<byte> Serialize(object value);
        bool TryDeserialize(ArraySegment<byte> bytes, [MaybeNullWhen(false)] out IncomingMessage message);
        object? Convert(object? value, Type type);
    }
}
