using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst.Interior.Filters
{
    internal interface IFilterExecutor<TMarker>
    {
        Task<object?> ExecuteAsync(IEnumerable<IFilter> filters, IInvocationContext<TMarker> context, Func<Task<object?>> endpoint);
    }
}
