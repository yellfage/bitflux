using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal interface IMessageDeserializerFactory<TMarker>
    {
        IMessageDeserializer<TMarker> Create(IProtocol<TMarker> protocol);
    }
}
