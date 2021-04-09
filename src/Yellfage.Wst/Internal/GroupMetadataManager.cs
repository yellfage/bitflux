using System.Collections.Generic;

namespace Yellfage.Wst.Internal
{
    internal class GroupMetadataManager<T> : MetadataManager<T>, IGroupMetadataManager<T>
    {
        public GroupMetadataManager(IDictionary<string, object> metadata) : base(metadata)
        {
        }
    }
}
