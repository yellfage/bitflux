using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace Yellfage.Wst.Interior
{
    internal class MethodExecutor<TMarker> : IMethodExecutor<TMarker>
    {
        public async Task<object?> ExecuteAsync(
            MethodInfo method,
            object target,
            IEnumerable<object?> arguments)
        {
            try
            {
                dynamic? result = method.Invoke(target, arguments.ToArray());

                if (method.IsAwaitable())
                {
                    await result;

                    string taskResultReturnTypeName = ( (object)result! )
                        .GetType()
                        .GetProperty("Result")!
                        .PropertyType
                        .FullName!;

                    if (taskResultReturnTypeName != "System.Threading.Tasks.VoidTaskResult")
                    {
                        return result!.GetAwaiter().GetResult();
                    }

                    return null;
                }

                return result;
            }
            catch (TargetInvocationException exception)
            {
                ExceptionDispatchInfo.Capture(exception.InnerException ?? exception).Throw();

                // Never reached

                throw;
            }
        }
    }
}
