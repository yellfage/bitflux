using System.Threading.Tasks;

using Yellfage.Bitflux.Interior.Filters;

namespace Yellfage.Bitflux.Interior.Invocation
{
    internal class InvocationExecutor<TMarker> : IInvocationExecutor<TMarker>
    {
        private IHandlerStore<TMarker> HandlerStore { get; }
        private IArgumentBinder<TMarker> ArgumentBinder { get; }
        private IFilterExecutor<TMarker> FilterExecutor { get; }
        private IHandlerExecutor<TMarker> HandlerExecutor { get; }
        private IInvocationResponder<TMarker> InvocationResponder { get; }

        public InvocationExecutor(
            IHandlerStore<TMarker> handlerStore,
            IArgumentBinder<TMarker> argumentBinder,
            IFilterExecutor<TMarker> filterExecutor,
            IHandlerExecutor<TMarker> handlerExecutor,
            IInvocationResponder<TMarker> invocationResponder)
        {
            HandlerStore = handlerStore;
            ArgumentBinder = argumentBinder;
            FilterExecutor = filterExecutor;
            HandlerExecutor = handlerExecutor;
            InvocationResponder = invocationResponder;
        }

        public async Task ExecuteAsync(IInvocationContext<TMarker> context)
        {
            if (HandlerStore.TryGet(context.HandlerName, out IHandler? handler))
            {
                try
                {
                    ArgumentBinder.BindMany(handler.Method.GetParameters(), context.Arguments);

                    object? result = await FilterExecutor.ExecuteAsync(
                        handler.Filters,
                        context,
                        () => HandlerExecutor.ExecuteAsync(handler, context));

                    await InvocationResponder.ReplyAsync(context, result);
                }
                catch (ArgumentBindingException exception)
                {
                    await InvocationResponder.ReplyErrorAsync(context, exception.Message);
                }
                catch (InvocationException exception)
                {
                    await InvocationResponder.ReplyErrorAsync(context, exception.Message);
                }
                catch
                {
                    await InvocationResponder.ReplyErrorAsync(context, "An unknown error has occurred");

                    throw;
                }
            }
            else
            {
                await InvocationResponder.ReplyErrorAsync(
                    context,
                    $"The \"{context.HandlerName}\" handler not found");
            }
        }
    }
}
