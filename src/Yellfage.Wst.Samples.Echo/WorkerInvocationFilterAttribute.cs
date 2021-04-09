using System;
using System.Threading.Tasks;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst.Samples.Echo
{
    public class WorkerInvocationFilterAttribute : Attribute, IInvocationFilter
    {
        public async Task ApplyAsync<T>(IInvocationContext<T> context, Func<Task> next)
        {
            Console.WriteLine("Worker invocation filter");

            await next();
        }
    }
}
