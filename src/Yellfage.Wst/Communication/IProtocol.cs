using System;

namespace Yellfage.Wst.Communication
{
    public interface IProtocol
    {
        string Name { get; }
        TransferFormat TransferFormat { get; }

        ArraySegment<byte> Serialize(object value);
        IncomingMessage Deserialize(ArraySegment<byte> bytes, IMessageTypeResolver messageTypeResolver);
        object? Convert(object? value, Type type);
    }
}
