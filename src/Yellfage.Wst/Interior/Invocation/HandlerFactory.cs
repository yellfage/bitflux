using System.Collections.Generic;
using System.Reflection;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst.Interior.Invocation
{
    internal class HandlerFactory<TMarker> : IHandlerFactory<TMarker>
    {
        public IHandler Create(MethodInfo method, IEnumerable<IFilter> filters)
        {
            return new Handler(method, filters);
        }
    }
}
