using System.Linq;
using System.Collections.Generic;

namespace Yellfage.Wst.Filters.Internal
{
    internal class FilterProvider : IFilterProvider
    {
        private IEnumerable<IFilter> Filters { get; }

        public FilterProvider(IEnumerable<IFilter> filters)
        {
            Filters = filters;
        }

        public IEnumerable<IConnectionFilter> GetConnectionFilters()
        {
            return Filters.OfType<IConnectionFilter>();
        }

        public IEnumerable<IDisconnectionFilter> GetDisconnectionFilters()
        {
            return Filters.OfType<IDisconnectionFilter>();
        }
    }
}
