using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace Yellfage.Wst.Filters.Internal
{
    internal class DisabledFilterTypeExplorer : IDisabledFilterTypeExplorer
    {
        public IEnumerable<Type> ExploreAll(MemberInfo memberInfo)
        {
            return memberInfo
                .GetCustomAttributes<DisableFilterAttribute>()
                .Select(attribute => attribute.Type);
        }
    }
}
