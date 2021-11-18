using System;
using System.Collections.Generic;

namespace Yellfage.Wst.Receptions.WebSockets
{
    public class WebSocketReceptionOptions<TMarker>
    {
        public ISet<string> AllowedOrigins { get; set; }
        public TimeSpan KeepAliveInterval { get; set; }
        public int MessageSegmentSize { get; set; }
        public int MaxMessageSegments { get; set; }

        public WebSocketReceptionOptions() : this(
                allowedOrigins: new HashSet<string>(),
                keepAliveInterval: TimeSpan.FromSeconds(30),
                messageSegmentSize: 4096,
                maxMessageSegments: 8)
        {
        }

        public WebSocketReceptionOptions(
            ISet<string> allowedOrigins,
            TimeSpan keepAliveInterval,
            int messageSegmentSize,
            int maxMessageSegments)
        {
            AllowedOrigins = allowedOrigins;
            KeepAliveInterval = keepAliveInterval;
            MessageSegmentSize = messageSegmentSize;
            MaxMessageSegments = maxMessageSegments;
        }
    }
}
