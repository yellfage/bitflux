using System.Collections.Generic;

using Yellfage.Bitflux.Caching;
using Yellfage.Bitflux.Interior.Disconnection;
using Yellfage.Bitflux.Interior.Notification;

namespace Yellfage.Bitflux.Interior
{
    internal class ClientFactory<TMarker> : IClientFactory<TMarker>
    {
        public IClient<TMarker> Create(
            string id,
            string ip,
            string userAgent,
            IDictionary<object, object> records,
            IClientClaimsPrincipal<TMarker> user,
            IClientCache<TMarker> clientCache,
            IClientNotifier<TMarker> clientNotifier,
            IClientDisconnector<TMarker> clientDisconnector)
        {
            return new Client<TMarker>(
                id,
                ip,
                userAgent,
                records,
                user,
                clientCache,
                clientNotifier,
                clientDisconnector);
        }
    }
}
