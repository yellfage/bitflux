using System;
using System.Threading.Tasks;

using Yellfage.Bitflux.Filters;

namespace Yellfage.Bitflux.Sample.Echo
{
    public class WorkerFilterAttribute : Attribute, IFilter
    {
        public Task<object?> ApplyAsync<TMarker>(
            IInvocationContext<TMarker> context,
            Func<Task<object?>> next)
        {
            Console.WriteLine("Worker filter");

            return next();
        }
    }
}
