using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior.Disconnection
{
    internal interface IClientDisconnectorFactory<TMarker>
    {
        IClientDisconnector<TMarker> Create(ITransport<TMarker> transport);
    }
}
