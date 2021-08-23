using System.Reflection;
using System.Collections.Generic;

using Yellfage.Wst.Filtration;

namespace Yellfage.Wst.Interior.Filtration
{
    internal interface IFilterExplorer
    {
        IEnumerable<IFilter> Explore(MemberInfo member);
    }
}
