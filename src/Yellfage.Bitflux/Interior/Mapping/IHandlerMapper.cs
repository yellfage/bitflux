using System.Collections.Generic;
using System.Reflection;

using Yellfage.Bitflux.Filters;

namespace Yellfage.Bitflux.Interior.Mapping
{
    internal interface IHandlerMapper<TMarker>
    {
        void Map(MethodInfo method, IEnumerable<IFilter> outerFilters);
    }
}
