using System.Threading.Tasks;

namespace Yellfage.Wst.Interior.Invocation
{
    internal interface IInvocationProcessor
    {
        Task ProcessAsync<TMarker>(IInvocationContext<TMarker> context);
    }
}
