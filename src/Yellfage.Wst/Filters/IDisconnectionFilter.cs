using System;
using System.Threading.Tasks;

namespace Yellfage.Wst.Filters
{
    public interface IDisconnectionFilter : IFilter
    {
        Task ApplyAsync<T>(IDisconnectionContext<T> context, Func<Task> next);
    }
}
