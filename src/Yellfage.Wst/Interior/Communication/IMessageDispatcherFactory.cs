using Yellfage.Wst.Interior.Invocation;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IMessageDispatcherFactory
    {
        IMessageDispatcher Create<TMarker>(IClient<TMarker> client, IMessageReceiver messageReceiver, IMessageTransmitter messageTransmitter, IInvocationProcessor invocationProcessor);
    }
}
