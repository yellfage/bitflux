using System.Collections.Generic;
using System.Reflection;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst.Interior.Mapping
{
    internal interface IHandlerMapper<TMarker>
    {
        void Map(MethodInfo method, IEnumerable<IFilter> outerFilters);
    }
}
