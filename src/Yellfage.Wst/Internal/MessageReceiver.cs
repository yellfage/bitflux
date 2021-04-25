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
        private WebSocket WebSocket { get; }
        private int MessageSegmentSize { get; }
        private int MaxMessageSize { get; }

        public MessageReceiver(WebSocket webSocket, int messageSegmentSize, int maxMessageSize)
        {
            WebSocket = webSocket;
            MessageSegmentSize = messageSegmentSize;
            MaxMessageSize = maxMessageSize;
        }

        public async Task StartReceivingAsync(Func<ArraySegment<byte>, Task> processMessageBytesAsync)
        {
            WebSocketReceiveResult receiveResult;

            try
            {
                while (true)
                {
                    receiveResult = await WebSocket.ReceiveAsync(
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
                        await processMessageBytesAsync.Invoke(messageSegment);

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

                    await processMessageBytesAsync.Invoke(fullMessage.ToArray());
                }
            }
            catch (WebSocketException)
            {
            }
        }
    }
}
