using System.Collections.Generic;
using System.Reflection;

using Yellfage.Bitflux.Filters;

namespace Yellfage.Bitflux.Interior.Invocation
{
    internal interface IHandlerFactory<TMarker>
    {
        IHandler Create(MethodInfo method, IEnumerable<IFilter> filters);
    }
}
