using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior.Invocation
{
    internal class ArgumentConverterFactory<TMarker> : IArgumentConverterFactory<TMarker>
    {
        public IArgumentConverter<TMarker> Create(IProtocol<TMarker> protocol)
        {
            return new ArgumentConverter<TMarker>(protocol);
        }
    }
}
