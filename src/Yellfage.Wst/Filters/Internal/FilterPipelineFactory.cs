using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yellfage.Wst.Filters.Internal
{
    internal class FilterPipelineFactory : IFilterPipelineFactory
    {
        public Func<Task> CreateConnectionPipeline<T>(
            IList<IConnectionFilter> filters,
            IConnectionContext<T> context,
            Func<Task> endpoint)
        {
            return filters
                .Reverse()
                .Aggregate(endpoint, (next, filter) => () => filter.ApplyAsync(context, next));
        }

        public Func<Task> CreateDisconnectionPipeline<T>(
            IList<IDisconnectionFilter> filters,
            IDisconnectionContext<T> context,
            Func<Task> endpoint)
        {
            return filters
                .Reverse()
                .Aggregate(endpoint, (next, filter) => () => filter.ApplyAsync(context, next));
        }

        public Func<Task> CreateInvocationPipeline<T>(
            IList<IInvocationFilter> filters,
            IInvocationContext<T> context,
            Func<Task> endpoint)
        {
            return filters
                .Reverse()
                .Aggregate(endpoint, (next, filter) => () => filter.ApplyAsync(context, next));
        }
    }
}