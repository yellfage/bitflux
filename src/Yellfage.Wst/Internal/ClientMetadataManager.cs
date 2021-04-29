using System.Collections.Generic;

namespace Yellfage.Wst.Internal
{
    internal class ClientMetadataManager<T> : MetadataManager<T>, IClientMetadataManager<T>
    {
        public ClientMetadataManager(IDictionary<string, object> metadata) : base(metadata)
        {
        }
    }
}
