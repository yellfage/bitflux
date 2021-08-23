using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal class ArgumentConverterFactory : IArgumentConverterFactory
    {
        public IArgumentConverter Create(IProtocol protocol)
        {
            return new ArgumentConverter(protocol);
        }
    }
}
