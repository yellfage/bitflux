using System;
using System.Collections.Generic;

namespace Yellfage.Wst.Configuration
{
    public class CommunicationSettings
    {
        public ISet<string> AllowedOrigins { get; set; }
        public TimeSpan KeepAliveInterval { get; set; }
        public int MessageSegmentSize { get; set; }
        public int MaxMessageSegments { get; set; }

        public CommunicationSettings() : this(
                allowedOrigins: new HashSet<string>(),
                keepAliveInterval: TimeSpan.FromSeconds(30),
                messageSegmentSize: 4096,
                maxMessageSegments: 8)
        {
        }

        public CommunicationSettings(
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

        internal void Validate()
        {
            ValidateAllowedOrigins();
            ValidateKeepAliveInterval();
            ValidateMessageSegmentSize();
            ValidateMaxMessageSegments();
        }

        private void ValidateAllowedOrigins()
        {
            if (AllowedOrigins is null)
            {
                throw new InvalidOperationException(
                    $"The '{nameof(AllowedOrigins)}' field cannot be null");
            }

            if (AllowedOrigins.Contains(null!))
            {
                throw new InvalidOperationException(
                    $"The '{nameof(AllowedOrigins)}' field cannot contain null");
            }
        }

        private void ValidateKeepAliveInterval()
        {
        }

        private void ValidateMessageSegmentSize()
        {
            if (MessageSegmentSize <= 0)
            {
                throw new InvalidOperationException(
                    $"The '{nameof(MessageSegmentSize)}' field cannot be less than 1");
            }
        }

        private void ValidateMaxMessageSegments()
        {
            if (MaxMessageSegments <= 0)
            {
                throw new InvalidOperationException(
                    $"The '{nameof(MaxMessageSegments)}' field cannot be less than 1");
            }
        }
    }
}
