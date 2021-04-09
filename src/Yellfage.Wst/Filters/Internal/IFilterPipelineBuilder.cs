using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yellfage.Wst.Filters.Internal
{
    internal interface IFilterPipelineBuilder
    {
        Func<Task> BuildConnectionPipeline<T>(IList<IConnectionFilter> filters, IConnectionContext<T> context, Func<Task> endpoint);
        Func<Task> BuildDisconnectionPipeline<T>(IList<IDisconnectionFilter> filters, IDisconnectionContext<T> context, Func<Task> endpoint);
        Func<Task> BuildInvocationPipeline<T>(IList<IInvocationFilter> filters, IInvocationContext<T> context, Func<Task> endpoint);
    }
}
