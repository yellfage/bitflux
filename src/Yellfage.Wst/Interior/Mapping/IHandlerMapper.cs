using System.Reflection;
using System.Collections.Generic;

using Yellfage.Wst.Filtration;

namespace Yellfage.Wst.Interior.Mapping
{
    internal interface IHandlerMapper
    {
        void Map(MethodInfo method, IEnumerable<IFilter> outerFilters);
    }
}
