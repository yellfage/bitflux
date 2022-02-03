using System.Collections.Generic;
using System.Reflection;

using Yellfage.Bitflux.Filters;

namespace Yellfage.Bitflux.Interior.Invocation
{
    internal class Handler : IHandler
    {
        public MethodInfo Method { get; }
        public IEnumerable<IFilter> Filters { get; }

        public Handler(MethodInfo method, IEnumerable<IFilter> filters)
        {
            Method = method;
            Filters = filters;
        }
    }
}
