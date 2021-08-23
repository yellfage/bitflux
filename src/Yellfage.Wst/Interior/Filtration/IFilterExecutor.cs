using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Yellfage.Wst.Filtration;

namespace Yellfage.Wst.Interior.Filtration
{
    internal interface IFilterExecutor
    {
        Task ExecuteAsync<TMarker>(IEnumerable<IFilter> filters, IInvocationContext<TMarker> context, Func<Task> endpoint);
    }
}
