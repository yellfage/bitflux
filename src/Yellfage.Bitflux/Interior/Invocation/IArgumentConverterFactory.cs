using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior.Invocation
{
    internal interface IArgumentConverterFactory<TMarker>
    {
        IArgumentConverter<TMarker> Create(IProtocol<TMarker> protocol);
    }
}
