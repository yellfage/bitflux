using System.Collections.Generic;
using System.Reflection;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst.Interior.Filters
{
    internal interface IFilterExplorer<TMarker>
    {
        IEnumerable<IFilter> Explore(MemberInfo member);
    }
}
