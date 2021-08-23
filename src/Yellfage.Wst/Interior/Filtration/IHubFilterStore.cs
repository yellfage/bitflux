using System.Collections.Generic;

using Yellfage.Wst.Filtration;

namespace Yellfage.Wst.Interior.Filtration
{
    internal interface IHubFilterStore
    {
        void AddRange(IEnumerable<IFilter> filters);
        IEnumerable<IFilter> GetAll();
    }
}
