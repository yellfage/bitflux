using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Yellfage.Wst.Interior.Communication;

namespace Yellfage.Wst.Interior.Invocation
{
    internal class RegularInvocationExecutionContext<TMarker> : InvocationExecutionContext<TMarker>
    {
        private string Id { get; }
        private bool Completed { get; set; }
        private IMessageTransmitter MessageTransmitter { get; }

        public RegularInvocationExecutionContext(
            IHub<TMarker> hub,
            IServiceProvider serviceProvider,
            IClient<TMarker> caller,
            string handlerName,
            IList<object?> arguments,
            string id,
            bool completed,
            IMessageTransmitter messageTransmitter) : base(
                hub,
                serviceProvider,
                caller,
                handlerName,
                arguments)
        {
            Id = id;
            Completed = completed;
            MessageTransmitter = messageTransmitter;
        }

        public override async Task ReplyAsync(
            object? result,
            CancellationToken cancellationToken = default)
        {
            var message = new OutgoingSuccessfulRegularInvocationResultMessage(
                Id,
                result);

            await SendResultMessageAsync(message, cancellationToken);
        }

        public override async Task ReplyErrorAsync(
            string error,
            CancellationToken cancellationToken = default)
        {
            var message = new OutgoingFailedRegularInvocationResultMessage(
                Id,
                error);

            await SendResultMessageAsync(message, cancellationToken);
        }

        private async Task SendResultMessageAsync(
            OutgoingRegularInvocationResultMessage message,
            CancellationToken cancellationToken)
        {
            if (Completed)
            {
                return;
            }

            Completed = true;

            await MessageTransmitter.TransmitAsync(message, cancellationToken);
        }
    }
}
