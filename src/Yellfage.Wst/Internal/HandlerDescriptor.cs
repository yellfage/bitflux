using System;
using System.Reflection;
using System.Collections.Generic;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst.Internal
{
    internal class HandlerDescriptor
    {
        public string Name { get; }
        public MethodInfo MethodInfo { get; }
        public MethodExecutor MethodExecutor { get; }
        public Type WorkerType { get; }
        public Type[] ParameterTypes { get; }
        public IList<IInvocationFilter> Filters { get; }

        public HandlerDescriptor(
            string name,
            MethodInfo methodInfo,
            MethodExecutor methodExecutor,
            Type workerType,
            Type[] parameterTypes,
            IList<IInvocationFilter> filters)
        {
            Name = name;
            MethodInfo = methodInfo;
            MethodExecutor = methodExecutor;
            WorkerType = workerType;
            ParameterTypes = parameterTypes;
            Filters = filters;
        }
    }
}
