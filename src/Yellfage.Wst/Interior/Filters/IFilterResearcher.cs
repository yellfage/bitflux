using System.Collections.Generic;
using System.Reflection;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst.Interior.Filters
{
    internal interface IFilterResearcher<TMarker>
    {
        IEnumerable<IFilter> Research(MemberInfo member, IEnumerable<IFilter> outerFilters);
    }
}
