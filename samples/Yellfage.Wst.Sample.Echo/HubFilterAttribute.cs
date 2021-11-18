using System;
using System.Threading.Tasks;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst.Sample.Echo
{
    public class HubFilterAttribute : Attribute, IFilter
    {
        public Task<object?> ApplyAsync<TMarker>(
            IInvocationContext<TMarker> context,
            Func<Task<object?>> next)
        {
            Console.WriteLine("Hub filter");

            return next();
        }
    }
}
