using System.Threading.Tasks;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal interface IInvocationMessageProcessor<TMarker>
    {
        Task ProcessAsync(IncomingInvocationMessage message);
    }
}
