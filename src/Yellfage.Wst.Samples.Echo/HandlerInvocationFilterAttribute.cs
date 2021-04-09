using System;
using System.Threading.Tasks;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst.Samples.Echo
{
    public class HandlerInvocationFilterAttribute : Attribute, IInvocationFilter
    {
        public async Task ApplyAsync<T>(IInvocationContext<T> context, Func<Task> next)
        {
            Console.WriteLine("Handler invocation filter");

            await next();
        }
    }
}
