using System;

namespace Yellfage.Bitflux.Communication
{
    public interface IProtocol<TMarker>
    {
        string Name { get; }
        TransferFormat TransferFormat { get; }

        ArraySegment<byte> Serialize(OutgoingMessage message);
        IncomingMessage? Deserialize(ArraySegment<byte> bytes, IMessageTypeResolver<TMarker> messageTypeResolver);
        object? Convert(Type type, object? value);
    }
}
