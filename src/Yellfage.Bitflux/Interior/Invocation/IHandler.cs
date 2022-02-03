using System.Collections.Generic;
using System.Reflection;

using Yellfage.Bitflux.Filters;

namespace Yellfage.Bitflux.Interior.Invocation
{
    internal interface IHandler
    {
        MethodInfo Method { get; }
        IEnumerable<IFilter> Filters { get; }
    }
}
