using System;
using System.Diagnostics.CodeAnalysis;

namespace Yellfage.Wst.Communication
{
    public interface IProtocol
    {
        string Name { get; }
        TransferFormat TransferFormat { get; }

        ArraySegment<byte> Serialize(OutgoingMessage message);
        bool TryDeserialize(ArraySegment<byte> bytes, [MaybeNullWhen(false)] out IncomingMessage message);
        bool TryConvertValue(object? value, Type type, [MaybeNullWhen(false)] out object? convertedValue);
    }
}
