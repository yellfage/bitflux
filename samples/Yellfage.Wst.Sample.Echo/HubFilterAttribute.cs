using System;
using System.Threading.Tasks;

using Yellfage.Wst.Filtration;

namespace Yellfage.Wst.Sample.Echo
{
    public class HubFilterAttribute : FilterAttribute
    {
        public override async Task ApplyAsync<T>(IInvocationContext<T> context, Func<Task> next)
        {
            Console.WriteLine("Hub filter");

            await next();
        }
    }
}
