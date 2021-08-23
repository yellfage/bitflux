using System;
using Microsoft.Extensions.DependencyInjection;

using Yellfage.Wst.Caching;
using Yellfage.Wst.Interior;

namespace Yellfage.Wst
{
    public abstract class Hub<TMarker> : Hub, IHub<TMarker>
    {
        public IClientManager<TMarker> Clients { get; }
        public IGroupManager<TMarker> Groups { get; }
        public IHubCache<TMarker> Cache { get; }

        public Hub(IServiceProvider serviceProvider)
        {
            Clients = serviceProvider
                .GetRequiredService<IClientManagerFactory>()
                .Create<TMarker>();

            Groups = serviceProvider
                .GetRequiredService<IGroupManagerFactory>()
                .Create<TMarker>();

            Cache = serviceProvider
                .GetRequiredService<IHubCacheFactory>()
                .Create<TMarker>();
        }
    }
}
