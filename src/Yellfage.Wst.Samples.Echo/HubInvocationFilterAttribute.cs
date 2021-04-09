using System;
using System.Threading.Tasks;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst.Samples.Echo
{
    public class HubInvocationFilterAttribute : Attribute, IInvocationFilter
    {
        public async Task ApplyAsync<T>(IInvocationContext<T> context, Func<Task> next)
        {
            Console.WriteLine("Hub invocation filter");

            await next();
        }
    }
}
