using System.Threading.Tasks;

using Yellfage.Wst.Interior.Communication;

namespace Yellfage.Wst.Interior.Invocation
{
    internal class RegularInvocationResponder<TMarker> : IRegularInvocationResponder<TMarker>
    {
        private IMessageTransmitter<TMarker> MessageTransmitter { get; }

        public RegularInvocationResponder(IMessageTransmitter<TMarker> messageTransmitter)
        {
            MessageTransmitter = messageTransmitter;
        }

        public async Task ReplyAsync(IInvocationContext<TMarker> context, object? value)
        {
            await SendMessage(
                new OutgoingSuccessfulRegularInvocationResultMessage(context.Id, value));
        }

        public async Task ReplyErrorAsync(IInvocationContext<TMarker> context, string error)
        {
            await SendMessage(
                new OutgoingFailedRegularInvocationResultMessage(context.Id, error));
        }

        private async Task SendMessage(OutgoingRegularInvocationResultMessage message)
        {
            await MessageTransmitter.TransmitAsync(message);
        }
    }
}
