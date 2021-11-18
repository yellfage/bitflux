using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst.Interior.Filters
{
    internal class FilterExplorer<TMarker> : IFilterExplorer<TMarker>
    {
        public IEnumerable<IFilter> Explore(MemberInfo member)
        {
            return member.GetCustomAttributes().OfType<IFilter>();
        }
    }
}
