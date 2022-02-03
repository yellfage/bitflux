using System.Threading.Tasks;

namespace Yellfage.Bitflux.Interior.Invocation
{
    internal class NotifiableInvocationResponder<TMarker> : INotifiableInvocationResponder<TMarker>
    {
        public Task ReplyAsync(IInvocationContext<TMarker> context, object? value)
        {
            return Task.CompletedTask;
        }

        public Task ReplyErrorAsync(IInvocationContext<TMarker> context, string error)
        {
            return Task.CompletedTask;
        }
    }
}
