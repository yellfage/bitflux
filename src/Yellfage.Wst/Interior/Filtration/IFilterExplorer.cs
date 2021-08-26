using System.Collections.Generic;
using System.Reflection;

using Yellfage.Wst.Filtration;

namespace Yellfage.Wst.Interior.Filtration
{
    internal interface IFilterExplorer
    {
        IEnumerable<IFilter> Explore(MemberInfo member);
    }
}
