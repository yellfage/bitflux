using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Yellfage.Bitflux.Interior
{
    internal interface IMethodExecutor<TMarker>
    {
        Task<object?> ExecuteAsync(MethodInfo method, object target, IEnumerable<object?> arguments);
    }
}
