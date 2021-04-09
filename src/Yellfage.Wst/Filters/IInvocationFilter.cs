using System;
using System.Threading.Tasks;

namespace Yellfage.Wst.Filters
{
    public interface IInvocationFilter : IFilter
    {
        Task ApplyAsync<T>(IInvocationContext<T> context, Func<Task> next);
    }
}
