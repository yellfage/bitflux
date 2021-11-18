using System.Collections.Generic;

using Yellfage.Wst.Caching;
using Yellfage.Wst.Interior.Disconnection;
using Yellfage.Wst.Interior.Notification;

namespace Yellfage.Wst.Interior
{
    internal interface IClientFactory<TMarker>
    {
        IClient<TMarker> Create(string id, string ip, string userAgent, IDictionary<object, object> records, IClientClaimsPrincipal<TMarker> user, IClientCache<TMarker> clientCache, IClientNotifier<TMarker> clientNotifier, IClientDisconnector<TMarker> clientDisconnector);
    }
}
