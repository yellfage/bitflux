using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Yellfage.Wst.Internal
{
    internal class HandlerExecutor : IHandlerExecutor
    {
        public async Task ExecuteAsync<T>(
            HandlerDescriptor handlerDescriptor,
            IInvocationContext<T> context)
        {
            var worker = (Worker<T>)context.ServiceProvider
                .GetRequiredService(handlerDescriptor.WorkerType);

            worker.Context = context;

            object? result = await handlerDescriptor
                .MethodExecutor
                .ExecuteAsync(worker, context.Args.ToArray());

            await context.ReplyAsync(result);
        }
    }
}
