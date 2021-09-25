using System.Collections.Generic;

using Yellfage.Wst.Caching;
using Yellfage.Wst.Interior.Communication;
using Yellfage.Wst.Interior.Disconnection;

namespace Yellfage.Wst.Interior
{
    internal class ClientFactory : IClientFactory
    {
        public IClient<TMarker> Create<TMarker>(
            string id,
            string ip,
            IDictionary<object, object> records,
            IClientClaimsPrincipal user,
            IClientCache<TMarker> cache,
            IMessageTransmitter messageTransmitter,
            IClientDisconnector clientDisconnector)
        {
            return new Client<TMarker>(
                id,
                ip,
                records,
                user,
                cache,
                messageTransmitter,
                clientDisconnector);
        }
    }
}
