using System.Collections.Generic;
using System.Reflection;

using Yellfage.Wst.Filtration;

namespace Yellfage.Wst.Interior.Filtration
{
    internal interface IFilterScreener
    {
        IEnumerable<IFilter> Screen(MemberInfo member, IEnumerable<IFilter> filters);
    }
}
