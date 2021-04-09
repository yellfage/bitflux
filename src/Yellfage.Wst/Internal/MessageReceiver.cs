using System;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yellfage.Wst.Internal
{
    internal class MessageReceiver : IMessageReceiver
    {
        private int MessageSegmentSize { get; }
        private int MaxMessageSize { get; }

        public MessageReceiver(int messageSegmentSize, int maxMessageSize)
        {
            MessageSegmentSize = messageSegmentSize;
            MaxMessageSize = maxMessageSize;
        }

        public async Task StartReceivingAsync(
            WebSocket webSocket,
            Func<ArraySegment<byte>, Task> processMessageBytesAsync)
        {
            WebSocketReceiveResult receiveResult;

            try
            {
                while (true)
                {
                    receiveResult = await webSocket.ReceiveAsync(
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

                    receiveResult = await webSocket.ReceiveAsync(
                        messageSegment,
                        CancellationToken.None);

                    if (receiveResult.EndOfMessage)
                    {
                        await processMessageBytesAsync.Invoke(messageSegment);

                        continue;
                    }

                    var fullMessage = new List<byte>();

                    do
                    {
                        if (fullMessage.Count >= MaxMessageSize)
                        {
                            await webSocket.CloseOutputAsync(
                                WebSocketCloseStatus.MessageTooBig,
                                "Message too big",
                                CancellationToken.None);

                            return;
                        }

                        fullMessage.AddRange(messageSegment.Take(receiveResult.Count));

                        messageSegment = new byte[MessageSegmentSize];

                        receiveResult = await webSocket.ReceiveAsync(messageSegment, CancellationToken.None);
                    }
                    while (!receiveResult.EndOfMessage);

                    fullMessage.AddRange(messageSegment.Take(receiveResult.Count));

                    await processMessageBytesAsync.Invoke(fullMessage.ToArray());
                }
            }
            catch (WebSocketException)
            {
            }
        }
    }
}
