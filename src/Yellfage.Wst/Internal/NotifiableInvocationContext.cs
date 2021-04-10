using System.Threading;
using System.Threading.Tasks;

namespace Yellfage.Wst.Internal
{
    internal class NotifiableInvocationContext<T> : InvocationContext<T>
    {
        public NotifiableInvocationContext(
            IHub<T> hub,
            IClient<T> caller,
            string handlerName,
            object?[] args) : base(hub, caller, handlerName, args)
        {
        }

        public override Task ReplyAsync(object? payload, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public override Task ReplyErrorAsync(string error, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
