using System;
using System.Threading.Tasks;

namespace Yellfage.Wst.Filtration
{
    public interface IFilter
    {
        int Priority { get; set; }

        Task ApplyAsync<TMarker>(IInvocationContext<TMarker> context, Func<Task> next);
    }
}
