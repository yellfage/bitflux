using System;
using System.Threading.Tasks;

namespace Yellfage.Wst.Filters
{
    public interface IFilter
    {
        /// <exception cref="InvocationException" />
        Task<object?> ApplyAsync<TMarker>(IInvocationContext<TMarker> context, Func<Task<object?>> next);
    }
}
