using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yellfage.Wst.Filters.Internal
{
    internal interface IFilterPipelineFactory
    {
        Func<Task> CreateConnectionPipeline<T>(IList<IConnectionFilter> filters, IConnectionContext<T> context, Func<Task> endpoint);
        Func<Task> CreateDisconnectionPipeline<T>(IList<IDisconnectionFilter> filters, IDisconnectionContext<T> context, Func<Task> endpoint);
        Func<Task> CreateInvocationPipeline<T>(IList<IInvocationFilter> filters, IInvocationContext<T> context, Func<Task> endpoint);
    }
}
