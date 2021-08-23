using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Yellfage.Wst.Interior.Communication;

namespace Yellfage.Wst.Interior.Invocation
{
    internal class RegularInvocationContext<TMarker> : InvocationContext<TMarker>
    {
        private string Id { get; }
        private bool Completed { get; set; }
        private IMessageTransmitter MessageTransmitter { get; }

        public RegularInvocationContext(
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
            object? value,
            CancellationToken cancellationToken = default)
        {
            var message = new OutgoingSuccessfulRegularInvocationResultMessage(
                Id,
                value);

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
