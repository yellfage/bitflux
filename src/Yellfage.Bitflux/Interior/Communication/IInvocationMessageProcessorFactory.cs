using Yellfage.Bitflux.Interior.Invocation;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal interface IInvocationMessageProcessorFactory<TMarker>
    {
        IInvocationMessageProcessor<TMarker> Create(IClient<TMarker> client, IArgumentBinder<TMarker> argumentBinder, IHandlerExecutor<TMarker> handlerExecutor, IRegularInvocationResponder<TMarker> regularInvocationResponder, INotifiableInvocationResponder<TMarker> notifiableInvocationResponder);
    }
}
