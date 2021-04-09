using System;
using System.Reflection;
using System.Collections.Generic;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst.Internal
{
    internal interface IHandlerDescriptorFactory
    {
        HandlerDescriptor Create(MethodInfo methodInfo, Type workerType, IEnumerable<IInvocationFilter> externalFilters);
    }
}
