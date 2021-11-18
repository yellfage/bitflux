using System.Collections.Generic;
using System.Reflection;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst.Interior.Invocation
{
    internal interface IHandlerFactory<TMarker>
    {
        IHandler Create(MethodInfo method, IEnumerable<IFilter> filters);
    }
}
