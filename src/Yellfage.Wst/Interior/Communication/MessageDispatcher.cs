using System;
using System.Threading.Tasks;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal class MessageDispatcher<TMarker> : IMessageDispatcher<TMarker>
    {
        private IInvocationMessageProcessor<TMarker> InvocationMessageProcessor { get; }
        private IMessageReceiver<TMarker> MessageReceiver { get; }

        public MessageDispatcher(
            IInvocationMessageProcessor<TMarker> invocationMessageProcessor,
            IMessageReceiver<TMarker> messageReceiver)
        {
            InvocationMessageProcessor = invocationMessageProcessor;
            MessageReceiver = messageReceiver;
        }

        public async Task StartAsync()
        {
            await MessageReceiver.StartAsync(ProcessMessageAsync);
        }

        private async Task ProcessMessageAsync(IncomingMessage incomingMessage)
        {
            switch (incomingMessage)
            {
                case IncomingInvocationMessage message:
                    await InvocationMessageProcessor.ProcessAsync(message);

                    break;

                default:
                    throw new InvalidOperationException(
                        "Unable to process icoming message: unknown message type");
            }
        }
    }
}
