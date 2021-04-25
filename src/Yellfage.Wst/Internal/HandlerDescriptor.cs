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
        public ParameterInfo[] ParametersInfo { get; }
        public IList<IInvocationFilter> Filters { get; }

        public HandlerDescriptor(
            string name,
            MethodInfo methodInfo,
            MethodExecutor methodExecutor,
            Type workerType,
            IList<IInvocationFilter> filters)
        {
            Name = name;
            MethodInfo = methodInfo;
            MethodExecutor = methodExecutor;
            WorkerType = workerType;
            ParametersInfo = MethodInfo.GetParameters();
            Filters = filters;
        }
    }
}
