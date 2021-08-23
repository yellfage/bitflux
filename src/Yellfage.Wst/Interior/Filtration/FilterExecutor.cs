using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Yellfage.Wst.Filtration;

namespace Yellfage.Wst.Interior.Filtration
{
    internal class FilterExecutor : IFilterExecutor
    {
        public async Task ExecuteAsync<TMarker>(
            IEnumerable<IFilter> filters,
            IInvocationContext<TMarker> context,
            Func<Task> endpoint)
        {
            await filters
                .Reverse()
                .Aggregate(endpoint, (next, filter) => () => filter.ApplyAsync(context, next))
                .Invoke();
        }
    }
}
