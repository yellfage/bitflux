using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Yellfage.Wst.Filtration;

namespace Yellfage.Wst.Interior.Filtration
{
    internal interface IFilterExecutor
    {
        Task ExecuteAsync<TMarker>(IEnumerable<IFilter> filters, IInvocationExecutionContext<TMarker> context, Func<Task> endpoint);
    }
}
