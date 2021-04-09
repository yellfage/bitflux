using System;
using System.Threading;
using System.Threading.Tasks;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Internal
{
    class ClientNotifier : IClientNotifier
    {
        private IMessageTransmitter MessageTransmitter { get; }

        public ClientNotifier(IMessageTransmitter messageTransmitter)
        {
            MessageTransmitter = messageTransmitter;
        }

        public async Task NotifyAsync(
            string handlerName,
            object?[] args,
            CancellationToken cancellationToken = default)
        {
            if (handlerName == null)
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            var message = new OutgoingNotifiableInvocationMessage(handlerName, args);

            await MessageTransmitter.TransmitAsync(message, cancellationToken);
        }
    }
}
