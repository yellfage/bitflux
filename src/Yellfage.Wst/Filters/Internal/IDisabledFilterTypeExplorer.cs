using System;
using System.Reflection;
using System.Collections.Generic;

namespace Yellfage.Wst.Filters.Internal
{
    internal interface IDisabledFilterTypeExplorer
    {
        IEnumerable<Type> ExploreAll(MemberInfo memberInfo);
    }
}
