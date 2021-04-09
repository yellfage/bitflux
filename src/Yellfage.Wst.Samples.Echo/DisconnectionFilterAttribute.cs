using System;
using System.Threading.Tasks;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst.Samples.Echo
{
    public class DisconnectionFilterAttribute : Attribute, IDisconnectionFilter
    {
        public async Task ApplyAsync<T>(IDisconnectionContext<T> context, Func<Task> next)
        {
            Console.WriteLine("Disconnection filter");

            await next();
        }
    }
}