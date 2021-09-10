using System;
using System.Threading.Tasks;

namespace Yellfage.Wst.Filtration
{
    public abstract class FilterAttribute : Attribute, IFilter
    {
        public int Priority { get; set; } = 0;

        public abstract Task ApplyAsync<TMarker>(IInvocationExecutionContext<TMarker> context, Func<Task> next);
    }
}
