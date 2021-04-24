using System.Collections.Concurrent;

using Yellfage.Wst.Internal;

namespace Yellfage.Wst
{
    public abstract class Hub<T> : IHub<T>
    {
        public IHubClientManager<T> Clients { get; }
        public IHubGroupManager<T> Groups { get; }
        public IHubMetadataManager<T> Metadata { get; }

        public Hub()
        {
            Clients = new HubClientManager<T>(new ConcurrentDictionary<string, IClient<T>>());
            Groups = new HubGroupManager<T>(new ConcurrentDictionary<string, IGroup<T>>());
            Metadata = new HubMetadataManager<T>(new ConcurrentDictionary<string, object>());
        }
    }
}
