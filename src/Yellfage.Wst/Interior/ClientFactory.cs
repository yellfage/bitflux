using System.Collections.Generic;

using Yellfage.Wst.Caching;
using Yellfage.Wst.Interior.Disconnection;
using Yellfage.Wst.Interior.Notification;

namespace Yellfage.Wst.Interior
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
