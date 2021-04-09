using System;
using System.Threading.Tasks;

namespace Yellfage.Wst.Filters
{
    public interface IConnectionFilter : IFilter
    {
        Task ApplyAsync<T>(IConnectionContext<T> context, Func<Task> next);
    }
}
