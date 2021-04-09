using System;
using System.Collections.Generic;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst
{
    public class HubOptions
    {
        public ISet<string> AllowedOrigins { get; }
        public TimeSpan KeepAliveInterval { get; set; }
        public int MessageSegmentSize { get; set; }
        public int MaxMessageSegments { get; set; }
        public IList<IProtocol> Protocols { get; }

        public HubOptions(
            ISet<string> allowedOrigins,
            TimeSpan keepAliveInterval,
            int messageSegmentSize,
            int maxMessageSegments,
            IList<IProtocol> protocols)
        {
            AllowedOrigins = allowedOrigins;
            KeepAliveInterval = keepAliveInterval;
            MessageSegmentSize = messageSegmentSize;
            MaxMessageSegments = maxMessageSegments;
            Protocols = protocols;
        }
    }
}
