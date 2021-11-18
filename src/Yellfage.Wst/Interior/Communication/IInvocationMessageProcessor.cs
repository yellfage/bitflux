using System.Threading.Tasks;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IInvocationMessageProcessor<TMarker>
    {
        Task ProcessAsync(IncomingInvocationMessage message);
    }
}
