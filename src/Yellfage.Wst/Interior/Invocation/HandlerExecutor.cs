using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

namespace Yellfage.Wst.Interior.Invocation
{
    internal class HandlerExecutor<TMarker> : IHandlerExecutor<TMarker>
    {
        private IArgumentBinder<TMarker> ArgumentBinder { get; }
        private IMethodExecutor<TMarker> MethodExecutor { get; }

        public HandlerExecutor(
            IArgumentBinder<TMarker> argumentBinder,
            IMethodExecutor<TMarker> methodExecutor)
        {
            ArgumentBinder = argumentBinder;
            MethodExecutor = methodExecutor;
        }

        /// <exception cref="ArgumentBindingException" />
        /// <exception cref="InvocationException" />
        public async Task<object?> ExecuteAsync(
            IHandler handler,
            IInvocationContext<TMarker> context)
        {
            ArgumentBinder.BindMany(handler.Method.GetParameters(), context.Arguments);

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
