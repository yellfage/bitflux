using System;
using System.Threading.Tasks;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst.Samples.Echo
{
    public class ConnectionFilterAttribute : Attribute, IConnectionFilter
    {
        public async Task ApplyAsync<T>(IConnectionContext<T> context, Func<Task> next)
        {
            Console.WriteLine("Connection filter");

            await next();
        }
    }
}