using System;
using System.Collections.Generic;

using Yellfage.Bitflux.Filters;

namespace Yellfage.Bitflux.Interior.Mapping
{
    internal interface IWorkerMapper<TMarker>
    {
        void Map(Type type, IEnumerable<IFilter> outerFilter);
    }
}
