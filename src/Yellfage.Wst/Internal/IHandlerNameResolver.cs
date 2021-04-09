using System.Reflection;

namespace Yellfage.Wst.Internal
{
    internal interface IHandlerNameResolver
    {
        string Resolve(MethodInfo methodInfo);
    }
}
