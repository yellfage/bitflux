using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Invocation
{
    internal interface IArgumentConverterFactory<TMarker>
    {
        IArgumentConverter<TMarker> Create(IProtocol<TMarker> protocol);
    }
}
