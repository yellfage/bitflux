using System.Reflection;

namespace Yellfage.Wst.Internal
{
    internal class HandlerNameResolver : IHandlerNameResolver
    {
        public string Resolve(MethodInfo methodInfo)
        {
            return methodInfo
                .GetCustomAttribute<HandlerNameAttribute>()?.Name ?? methodInfo.Name;
        }
    }
}
