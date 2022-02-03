using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Yellfage.Bitflux.Filters;

namespace Yellfage.Bitflux.Interior.Filters
{
    internal interface IFilterExecutor<TMarker>
    {
        Task<object?> ExecuteAsync(IEnumerable<IFilter> filters, IInvocationContext<TMarker> context, Func<Task<object?>> endpoint);
    }
}
