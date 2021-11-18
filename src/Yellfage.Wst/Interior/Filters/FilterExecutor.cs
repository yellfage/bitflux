using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst.Interior.Filters
{
    internal class FilterExecutor<TMarker> : IFilterExecutor<TMarker>
    {
        public async Task<object?> ExecuteAsync(
            IEnumerable<IFilter> filters,
            IInvocationContext<TMarker> context,
            Func<Task<object?>> endpoint)
        {
            return await filters
                .Reverse()
                .Aggregate(endpoint, (next, filter) => () => filter.ApplyAsync(context, next))
                .Invoke();
        }
    }
}
