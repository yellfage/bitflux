using System.Reflection;
using System.Threading.Tasks;

namespace Yellfage.Wst.Internal
{
    internal class MethodExecutor
    {
        private MethodInfo MethodInfo { get; }
        private bool IsAwaitable { get; }

        public MethodExecutor(MethodInfo methodInfo, bool isAwaitable)
        {
            MethodInfo = methodInfo;
            IsAwaitable = isAwaitable;
        }

        public async Task<object?> ExecuteAsync(
            object? obj,
            params object?[] args)
        {
            dynamic? result = MethodInfo.Invoke(obj, args);

            if (IsAwaitable)
            {
                await result;

                return result!.GetAwaiter().GetResult();
            }

            return result;
        }
    }
}
