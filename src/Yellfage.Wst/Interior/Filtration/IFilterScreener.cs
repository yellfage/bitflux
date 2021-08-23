using System.Reflection;
using System.Collections.Generic;

using Yellfage.Wst.Filtration;

namespace Yellfage.Wst.Interior.Filtration
{
    internal interface IFilterScreener
    {
        IEnumerable<IFilter> Screen(MemberInfo member, IEnumerable<IFilter> filters);
    }
}
