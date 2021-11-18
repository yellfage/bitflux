using Yellfage.Wst.Interior.Communication;

namespace Yellfage.Wst.Interior.Connection
{
    internal interface IConnectionProcessorFactory<TMarker>
    {
        IConnectionProcessor<TMarker> Create(IClient<TMarker> client, IMessageDispatcher<TMarker> messageDispatcher);
    }
}
