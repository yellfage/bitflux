using System.Collections.Generic;

namespace Yellfage.Wst
{
    public interface IMetadataManager<T>
    {
        IDictionary<string, object> All { get; }
    }
}
