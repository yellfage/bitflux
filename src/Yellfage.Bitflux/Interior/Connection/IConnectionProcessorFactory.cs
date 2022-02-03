using Yellfage.Bitflux.Interior.Communication;

namespace Yellfage.Bitflux.Interior.Connection
{
    internal interface IConnectionProcessorFactory<TMarker>
    {
        IConnectionProcessor<TMarker> Create(IClient<TMarker> client, IMessageDispatcher<TMarker> messageDispatcher);
    }
}
