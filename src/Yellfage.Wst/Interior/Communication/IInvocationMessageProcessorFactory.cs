using Yellfage.Wst.Interior.Invocation;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IInvocationMessageProcessorFactory<TMarker>
    {
        IInvocationMessageProcessor<TMarker> Create(IClient<TMarker> client, IHandlerExecutor<TMarker> handlerExecutor, IRegularInvocationResponder<TMarker> regularInvocationResponder, INotifiableInvocationResponder<TMarker> notifiableInvocationResponder);
    }
}
