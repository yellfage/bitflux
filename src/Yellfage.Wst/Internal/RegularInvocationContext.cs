using System.Threading;
using System.Threading.Tasks;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Internal
{
    internal class RegularInvocationContext<T> : InvocationContext<T>
    {
        private string InvocationId { get; }
        private bool Completed { get; set; }
        private IMessageTransmitter MessageTransmitter { get; }

        public RegularInvocationContext(
            IHub<T> hub,
            IClient<T> caller,
            string handlerName,
            object?[] args,
            string invocationId,
            bool completed,
            IMessageTransmitter messageTransmitter) : base(hub, caller, handlerName, args)
        {
            InvocationId = invocationId;
            Completed = completed;
            MessageTransmitter = messageTransmitter;
        }

        public override async Task ReplyAsync(
            object? payload,
            CancellationToken cancellationToken = default)
        {
            var message = new OutgoingSuccessRegularInvocationCompletionMessage(
                InvocationId,
                payload);

            await SendCompletionMessageAsync(message, cancellationToken);
        }

        public override async Task ReplyErrorAsync(
            string error,
            CancellationToken cancellationToken = default)
        {
            var message = new OutgoingFailedRegularInvocationCompletionMessage(
                InvocationId,
                error);

            await SendCompletionMessageAsync(message, cancellationToken);
        }

        private async Task SendCompletionMessageAsync(
            OutgoingRegularInvocationCompletionMessage message,
            CancellationToken cancellationToken)
        {
            /*
             * We need to check a token because the token
             * can be already cancelled before sending a response.
             * Setting Completed = true will prevent a response from being sent next time
             */
            cancellationToken.ThrowIfCancellationRequested();

            if (Completed)
            {
                return;
            }

            Completed = true;

            await MessageTransmitter.TransmitAsync(message, cancellationToken);
        }
    }
}
