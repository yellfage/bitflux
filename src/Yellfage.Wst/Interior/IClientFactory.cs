using Yellfage.Wst.Caching;
using Yellfage.Wst.Interior.Communication;
using Yellfage.Wst.Interior.Disconnection;

namespace Yellfage.Wst.Interior
{
    internal interface IClientFactory
    {
        IClient<TMarker> Create<TMarker>(string id, IClientClaimsPrincipal user, IClientCache<TMarker> cache, IMessageTransmitter messageTransmitter, IClientDisconnector clientDisconnector);
    }
}
