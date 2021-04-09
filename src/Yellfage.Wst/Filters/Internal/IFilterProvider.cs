using System.Collections.Generic;

namespace Yellfage.Wst.Filters.Internal
{
    internal interface IFilterProvider
    {
        IEnumerable<IConnectionFilter> GetConnectionFilters();
        IEnumerable<IDisconnectionFilter> GetDisconnectionFilters();
    }
}
