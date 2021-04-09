using System.Collections.Generic;

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
            Clients = new HubClientManager<T>(new List<IClient<T>>());
            Groups = new HubGroupManager<T>(new Dictionary<string, IGroup<T>>());
            Metadata = new HubMetadataManager<T>(new Dictionary<string, object>());
        }
    }
}
