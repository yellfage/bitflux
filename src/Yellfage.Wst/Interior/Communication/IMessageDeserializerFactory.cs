using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IMessageDeserializerFactory
    {
        IMessageDeserializer Create(IProtocol protocol);
    }
}
