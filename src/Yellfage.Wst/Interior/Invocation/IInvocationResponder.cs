using System.Threading.Tasks;

namespace Yellfage.Wst.Interior.Invocation
{
    internal interface IInvocationResponder<TMarker>
    {
        Task ReplyAsync(IInvocationContext<TMarker> context, object? value);
        Task ReplyErrorAsync(IInvocationContext<TMarker> context, string error);
    }
}
