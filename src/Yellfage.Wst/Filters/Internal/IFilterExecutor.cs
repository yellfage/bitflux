using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yellfage.Wst.Filters.Internal
{
    internal interface IFilterExecutor
    {
        Task ExecuteConnectionFiltersAsync<T>(IList<IConnectionFilter> filters, IConnectionContext<T> context, Func<Task> endpoint);
        Task ExecuteDisconnectionFiltersAsync<T>(IList<IDisconnectionFilter> filters, IDisconnectionContext<T> context, Func<Task> endpoint);
        Task ExecuteInvocationFiltersAsync<T>(IList<IInvocationFilter> filters, IInvocationContext<T> context, Func<Task> endpoint);
    }
}
