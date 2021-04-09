using System.Collections.Generic;

namespace Yellfage.Wst.Internal
{
    internal class HubMetadataManager<T> : MetadataManager<T>, IHubMetadataManager<T>
    {
        public HubMetadataManager(IDictionary<string, object> metadata) : base(metadata)
        {
        }
    }
}
