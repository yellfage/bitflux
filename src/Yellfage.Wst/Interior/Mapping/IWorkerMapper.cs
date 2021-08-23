using System;
using System.Collections.Generic;

using Yellfage.Wst.Filtration;

namespace Yellfage.Wst.Interior.Mapping
{
    internal interface IWorkerMapper
    {
        void Map(Type type, IEnumerable<IFilter> outerFilters);
    }
}
