using System.Collections.Generic;
using System.Reflection;

using Yellfage.Bitflux.Filters;

namespace Yellfage.Bitflux.Interior.Filters
{
    internal interface IFilterResearcher<TMarker>
    {
        IEnumerable<IFilter> Research(MemberInfo member, IEnumerable<IFilter> outerFilters);
    }
}
