using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior.Disconnection
{
    internal class ClientDisconnectorFactory<TMarker> : IClientDisconnectorFactory<TMarker>
    {
        public IClientDisconnector<TMarker> Create(ITransport<TMarker> transport)
        {
            return new ClientDisconnector<TMarker>(transport);
        }
    }
}
