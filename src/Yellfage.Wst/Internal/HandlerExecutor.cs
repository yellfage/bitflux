using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Yellfage.Wst.Internal
{
    internal class HandlerExecutor : IHandlerExecutor
    {
        private IServiceProvider GlobalServiceProvider { get; }

        public HandlerExecutor(IServiceProvider globalServiceProvider)
        {
            GlobalServiceProvider = globalServiceProvider;
        }

        public async Task ExecuteAsync<T>(
            HandlerDescriptor handlerDescriptor,
            IInvocationContext<T> context)
        {
            var worker = (Worker<T>)GlobalServiceProvider
                .GetRequiredService(handlerDescriptor.WorkerType);

            worker.Context = context;

            object? result = await handlerDescriptor
                .MethodExecutor
                .ExecuteAsync(worker, context.Args);

            await context.ReplyAsync(result);
        }
    }
}
