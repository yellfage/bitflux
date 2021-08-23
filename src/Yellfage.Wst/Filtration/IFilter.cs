using System;
using System.Threading.Tasks;

namespace Yellfage.Wst.Filtration
{
    public interface IFilter
    {
        int Priority => FilterPriority.Default;

        Task ApplyAsync<TMarker>(IInvocationContext<TMarker> context, Func<Task> next);
    }
}
