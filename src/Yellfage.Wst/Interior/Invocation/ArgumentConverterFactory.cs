using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Invocation
{
    internal class ArgumentConverterFactory<TMarker> : IArgumentConverterFactory<TMarker>
    {
        public IArgumentConverter<TMarker> Create(IProtocol<TMarker> protocol)
        {
            return new ArgumentConverter<TMarker>(protocol);
        }
    }
}
