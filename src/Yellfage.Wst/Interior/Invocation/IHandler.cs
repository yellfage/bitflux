using System.Collections.Generic;
using System.Reflection;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst.Interior.Invocation
{
    internal interface IHandler
    {
        MethodInfo Method { get; }
        IEnumerable<IFilter> Filters { get; }
    }
}
