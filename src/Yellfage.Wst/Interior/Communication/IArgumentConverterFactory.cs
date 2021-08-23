using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IArgumentConverterFactory
    {
        IArgumentConverter Create(IProtocol protocol);
    }
}
