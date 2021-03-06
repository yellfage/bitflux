using System.Collections.Generic;
using System.Reflection;

using Yellfage.Bitflux.Filters;

namespace Yellfage.Bitflux.Interior.Invocation
{
    internal class HandlerFactory<TMarker> : IHandlerFactory<TMarker>
    {
        public IHandler Create(MethodInfo method, IEnumerable<IFilter> filters)
        {
            return new Handler(method, filters);
        }
    }
}
