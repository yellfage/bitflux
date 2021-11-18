using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IMessageDeserializerFactory<TMarker>
    {
        IMessageDeserializer<TMarker> Create(IProtocol<TMarker> protocol);
    }
}
