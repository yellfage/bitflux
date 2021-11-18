using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Disconnection
{
    internal interface IClientDisconnectorFactory<TMarker>
    {
        IClientDisconnector<TMarker> Create(ITransport<TMarker> transport);
    }
}
