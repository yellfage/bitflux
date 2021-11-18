using System;
using System.Collections.Generic;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst.Interior.Mapping
{
    internal interface IWorkerMapper<TMarker>
    {
        void Map(Type type, IEnumerable<IFilter> outerFilter);
    }
}
