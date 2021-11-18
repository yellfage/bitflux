using System;
using System.Threading.Tasks;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal class MessageReceiver<TMarker> : IMessageReceiver<TMarker>
    {
        private ITransport<TMarker> Transport { get; }
        private IMessageDeserializer<TMarker> MessageDeserializer { get; }

        public MessageReceiver(ITransport<TMarker> transport, IMessageDeserializer<TMarker> messageDeserializer)
        {
            Transport = transport;
            MessageDeserializer = messageDeserializer;
        }

        public async Task StartAsync(Func<IncomingMessage, Task> messageHandler)
        {
            await Transport.StartAsync(async bytes =>
            {
                if (MessageDeserializer.TryDeserialize(bytes, out IncomingMessage? message))
                {
                    if (!message.IsValid())
                    {
                        await Transport.StopAsync("The incoming message is invalid");

                        return;
                    }

                    await messageHandler.Invoke(message);
                }
                else
                {
                    await Transport.StopAsync("Unable to deserialize the received message");

                    return;
                }
            });
        }
    }
}
