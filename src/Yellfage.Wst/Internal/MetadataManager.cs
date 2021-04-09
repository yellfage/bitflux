using System.Collections.Generic;

namespace Yellfage.Wst.Internal
{
    internal abstract class MetadataManager<T> : IMetadataManager<T>
    {
        public IDictionary<string, object> All { get; }

        public MetadataManager(IDictionary<string, object> metadata)
        {
            All = metadata;
        }
    }
}
