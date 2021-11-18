using System.Collections.Generic;
using System.Reflection;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst.Interior.Invocation
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
