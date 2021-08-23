using Yellfage.Wst.Interior.Communication;

namespace Yellfage.Wst.Interior.Connection
{
    internal interface IConnectionProcessorFactory
    {
        IConnectionProcessor Create<TMarker>(IClient<TMarker> client, IMessageDispatcher messageDispatcher);
    }
}
