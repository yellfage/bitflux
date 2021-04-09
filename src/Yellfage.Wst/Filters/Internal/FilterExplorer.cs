using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace Yellfage.Wst.Filters.Internal
{
    internal class FilterExplorer : IFilterExplorer
    {
        public IEnumerable<IFilter> ExploreAllFilters(MemberInfo memberInfo)
        {
            return memberInfo.GetCustomAttributes().OfType<IFilter>();
        }

        public IEnumerable<IInvocationFilter> ExploreInvocationFilters(MemberInfo memberInfo)
        {
            return ExploreAllFilters(memberInfo).OfType<IInvocationFilter>();
        }
    }
}
