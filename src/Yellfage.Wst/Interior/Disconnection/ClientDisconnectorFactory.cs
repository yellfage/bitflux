using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Disconnection
{
    internal class ClientDisconnectorFactory<TMarker> : IClientDisconnectorFactory<TMarker>
    {
        public IClientDisconnector<TMarker> Create(ITransport<TMarker> transport)
        {
            return new ClientDisconnector<TMarker>(transport);
        }
    }
}
