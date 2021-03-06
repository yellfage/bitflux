using System;

using Microsoft.Extensions.DependencyInjection;

using Yellfage.Bitflux.Caching;

namespace Yellfage.Bitflux
{
    public abstract class Hub<TMarker> : IHub<TMarker>
    {
        public IClientManager<TMarker> Clients { get; }
        public IGroupManager<TMarker> Groups { get; }
        public IHubCache<TMarker> Cache { get; }

        public Hub(IServiceProvider serviceProvider)
        {
            Clients = serviceProvider.GetRequiredService<IClientManager<TMarker>>();
            Groups = serviceProvider.GetRequiredService<IGroupManager<TMarker>>();
            Cache = serviceProvider.GetRequiredService<IHubCache<TMarker>>();
        }
    }
}
