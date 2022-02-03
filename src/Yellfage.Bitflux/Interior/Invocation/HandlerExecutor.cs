using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

namespace Yellfage.Bitflux.Interior.Invocation
{
    internal class HandlerExecutor<TMarker> : IHandlerExecutor<TMarker>
    {
        private IMethodExecutor<TMarker> MethodExecutor { get; }

        public HandlerExecutor(IMethodExecutor<TMarker> methodExecutor)
        {
            MethodExecutor = methodExecutor;
        }

        /// <exception cref="ArgumentBindingException" />
        /// <exception cref="InvocationException" />
        public async Task<object?> ExecuteAsync(
            IHandler handler,
            IInvocationContext<TMarker> context)
        {
            var worker = (IWorker<TMarker>)context
                .ServiceProvider
                .GetRequiredService(handler.Method.DeclaringType!);

            worker.Context = context;

            object? result = await MethodExecutor
                .ExecuteAsync(handler.Method, worker, context.Arguments);

            return result;
        }
    }
}
