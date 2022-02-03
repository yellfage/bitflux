using System.Collections.Generic;

using Yellfage.Bitflux.Caching;
using Yellfage.Bitflux.Interior.Disconnection;
using Yellfage.Bitflux.Interior.Notification;

namespace Yellfage.Bitflux.Interior
{
    internal interface IClientFactory<TMarker>
    {
        IClient<TMarker> Create(string id, string ip, string userAgent, IDictionary<object, object> records, IClientClaimsPrincipal<TMarker> user, IClientCache<TMarker> clientCache, IClientNotifier<TMarker> clientNotifier, IClientDisconnector<TMarker> clientDisconnector);
    }
}
