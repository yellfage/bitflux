using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yellfage.Wst.Filters.Internal
{
    internal class FilterExecutor : IFilterExecutor
    {
        private IFilterPipelineFactory FilterPipelineFactory { get; }

        public FilterExecutor(IFilterPipelineFactory filterPipelineFactory)
        {
            FilterPipelineFactory = filterPipelineFactory;
        }

        public async Task ExecuteConnectionFiltersAsync<T>(
            IList<IConnectionFilter> filters,
            IConnectionContext<T> context,
            Func<Task> endpoint)
        {
            await FilterPipelineFactory
                    .CreateConnectionPipeline(filters, context, endpoint)
                    .Invoke();
        }

        public async Task ExecuteDisconnectionFiltersAsync<T>(
            IList<IDisconnectionFilter> filters,
            IDisconnectionContext<T> context,
            Func<Task> endpoint)
        {
            await FilterPipelineFactory
                    .CreateDisconnectionPipeline(filters, context, endpoint)
                    .Invoke();
        }

        public async Task ExecuteInvocationFiltersAsync<T>(
            IList<IInvocationFilter> filters,
            IInvocationContext<T> context,
            Func<Task> endpoint)
        {
            await FilterPipelineFactory
                    .CreateInvocationPipeline(filters, context, endpoint)
                    .Invoke();
        }
    }
}
