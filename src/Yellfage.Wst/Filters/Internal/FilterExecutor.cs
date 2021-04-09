using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yellfage.Wst.Filters.Internal
{
    internal class FilterExecutor : IFilterExecutor
    {
        private IFilterPipelineBuilder FilterPipelineBuilder { get; }

        public FilterExecutor(IFilterPipelineBuilder filterPipelineBuilder)
        {
            FilterPipelineBuilder = filterPipelineBuilder;
        }

        public async Task ExecuteConnectionFiltersAsync<T>(
            IList<IConnectionFilter> filters,
            IConnectionContext<T> context,
            Func<Task> endpoint)
        {
            await FilterPipelineBuilder
                    .BuildConnectionPipeline(filters, context, endpoint)
                    .Invoke();
        }

        public async Task ExecuteDisconnectionFiltersAsync<T>(
            IList<IDisconnectionFilter> filters,
            IDisconnectionContext<T> context,
            Func<Task> endpoint)
        {
            await FilterPipelineBuilder
                    .BuildDisconnectionPipeline(filters, context, endpoint)
                    .Invoke();
        }

        public async Task ExecuteInvocationFiltersAsync<T>(
            IList<IInvocationFilter> filters,
            IInvocationContext<T> context,
            Func<Task> endpoint)
        {
            await FilterPipelineBuilder
                    .BuildInvocationPipeline(filters, context, endpoint)
                    .Invoke();
        }
    }
}
