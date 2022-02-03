using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;

namespace Yellfage.Bitflux.Receptions.WebSockets
{
    internal class MessageReceiver<TMarker> : IMessageReceiver<TMarker>
    {
        private int MessageSegmentSize { get; }
        private int MaxMessageSegments { get; }

        public MessageReceiver(IOptions<WebSocketReceptionOptions<TMarker>> options) : this(
                options.Value.MessageSegmentSize,
                options.Value.MaxMessageSegments)
        {
        }

        public MessageReceiver(int messageSegmentSize, int maxMessageSegments)
        {
            MessageSegmentSize = messageSegmentSize;
            MaxMessageSegments = maxMessageSegments;
        }

        public async Task StartAsync(
            WebSocket webSocket,
            Func<ArraySegment<byte>, Task> processBytesAsync)
        {
            try
            {
                while (true)
                {
                    WebSocketReceiveResult receiveResult = await webSocket.ReceiveAsync(
                        new byte[] { },
                        default);

                    if (receiveResult.MessageType == WebSocketMessageType.Close)
                    {
                        await webSocket.CloseOutputAsync(
                            webSocket.CloseStatus ?? WebSocketCloseStatus.NormalClosure,
                            webSocket.CloseStatusDescription,
                            default);

                        return;
                    }

                    if (receiveResult.EndOfMessage)
                    {
                        continue;
                    }

                    byte[] messageSegment = new byte[MessageSegmentSize];

                    receiveResult = await webSocket.ReceiveAsync(messageSegment, default);

                    if (receiveResult.EndOfMessage)
                    {
                        await processBytesAsync(messageSegment);

                        continue;
                    }

                    var messageSegments = new List<byte[]>();

                    do
                    {
                        if (messageSegments.Count >= MaxMessageSegments)
                        {
                            await webSocket.CloseOutputAsync(
                                WebSocketCloseStatus.MessageTooBig,
                                "Message too big",
                                default);

                            return;
                        }

                        messageSegments.Add(messageSegment);

                        messageSegment = new byte[MessageSegmentSize];

                        receiveResult = await webSocket.ReceiveAsync(messageSegment, default);
                    }
                    while (!receiveResult.EndOfMessage);

                    messageSegments.Add(messageSegment);

                    ArraySegment<byte> finalMessageSegment = messageSegments.Aggregate(
                        new ArraySegment<byte>(),
                        (result, segment) => result.Concat(segment).ToArray());

                    await processBytesAsync(finalMessageSegment);
                }
            }
            catch (WebSocketException)
            {
            }
        }
    }
}
