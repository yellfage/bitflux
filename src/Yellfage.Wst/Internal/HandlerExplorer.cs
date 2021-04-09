using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace Yellfage.Wst.Internal
{
    internal class HandlerExplorer : IHandlerExplorer
    {
        public IList<MethodInfo> ExploreWorker(Type workerType)
        {
            return workerType
                .GetMethods(
                    BindingFlags.Public |
                    BindingFlags.InvokeMethod |
                    BindingFlags.Instance |
                    BindingFlags.DeclaredOnly)
                .Where(methodInfo => !methodInfo.IsSpecialName
                                     && !methodInfo.IsGenericMethod)
                .ToList();
        }
    }
}
