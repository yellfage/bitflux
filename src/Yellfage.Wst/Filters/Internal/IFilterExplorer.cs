using System.Reflection;
using System.Collections.Generic;

namespace Yellfage.Wst.Filters.Internal
{
    internal interface IFilterExplorer
    {
        IEnumerable<IFilter> ExploreAllFilters(MemberInfo memberInfo);
        IEnumerable<IInvocationFilter> ExploreInvocationFilters(MemberInfo memberInfo);
    }
}
