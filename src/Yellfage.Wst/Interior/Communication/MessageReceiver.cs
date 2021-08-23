using System;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal class MessageReceiver : IMessageReceiver
    {
        private int MessageSegmentSize { get; }
        private int MaxMessageSize { get; }
        private WebSocket WebSocket { get; }
        private IMessageDeserializer MessageDeserializer { get; }

        public MessageReceiver(
            int messageSegmentSize,
            int maxMessageSize,
            WebSocket webSocket,
            IMessageDeserializer messageDeserializer)
        {
            MessageSegmentSize = messageSegmentSize;
            MaxMessageSize = maxMessageSize;
            WebSocket = webSocket;
            MessageDeserializer = messageDeserializer;
        }

        public async Task StartReceivingAsync(Func<IncomingMessage, Task> processMessageAsync)
        {
            await StartBytesReceivingAsync(async bytes =>
            {
                if (MessageDeserializer.TryDeserialize(bytes, out IncomingMessage? message))
                {
                    if (!message.IsValid())
                    {
                        await WebSocket.CloseOutputAsync(
                            WebSocketCloseStatus.ProtocolError,
                            "The incoming message is invalid",
                            CancellationToken.None);

                        return;
                    }

                    await processMessageAsync.Invoke(message);
                }
                else
                {
                    await WebSocket.CloseOutputAsync(
                        WebSocketCloseStatus.ProtocolError,
                        "Unable to deserialize the received message",
                        CancellationToken.None);

                    return;
                }
            });
        }

        private async Task StartBytesReceivingAsync(
            Func<ArraySegment<byte>, Task> processBytesAsync)
        {
            try
            {
                while (true)
                {
                    WebSocketReceiveResult receiveResult = await WebSocket.ReceiveAsync(
                        Array.Empty<byte>(),
                        CancellationToken.None);

                    if (receiveResult.MessageType == WebSocketMessageType.Close)
                    {
                        return;
                    }

                    if (receiveResult.EndOfMessage)
                    {
                        continue;
                    }

                    byte[] messageSegment = new byte[MessageSegmentSize];

                    receiveResult = await WebSocket.ReceiveAsync(
                        messageSegment,
                        CancellationToken.None);

                    if (receiveResult.EndOfMessage)
                    {
                        await processBytesAsync.Invoke(messageSegment);

                        continue;
                    }

                    var fullMessage = new List<byte>();

                    do
                    {
                        if (fullMessage.Count >= MaxMessageSize)
                        {
                            await WebSocket.CloseOutputAsync(
                                WebSocketCloseStatus.MessageTooBig,
                                "Message too big",
                                CancellationToken.None);

                            return;
                        }

                        fullMessage.AddRange(messageSegment.AsEnumerable());

                        messageSegment = new byte[MessageSegmentSize];

                        receiveResult = await WebSocket.ReceiveAsync(messageSegment, CancellationToken.None);
                    }
                    while (!receiveResult.EndOfMessage);

                    fullMessage.AddRange(messageSegment.AsEnumerable());

                    await processBytesAsync.Invoke(fullMessage.ToArray());
                }
            }
            catch (WebSocketException)
            {
            }
        }
    }
}
