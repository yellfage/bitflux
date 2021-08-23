using System;
using System.Collections.Generic;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Configuration
{
    public class CommunicationSettings
    {
        public ISet<string> AllowedOrigins { get; set; }
        public TimeSpan KeepAliveInterval { get; set; }
        public int MessageSegmentSize { get; set; }
        public int MaxMessageSegments { get; set; }
        public IList<IProtocol> Protocols { get; set; }

        public CommunicationSettings() : this(
                new HashSet<string>(),
                TimeSpan.FromSeconds(30),
                4096,
                8,
                new List<IProtocol>())
        {
        }

        public CommunicationSettings(
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

        internal void Validate()
        {
            ValidateAllowedOrigins();
            ValidateKeepAliveInterval();
            ValidateMessageSegmentSize();
            ValidateMaxMessageSegments();
            ValidateProtocols();
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

        private void ValidateProtocols()
        {
            if (Protocols is null)
            {
                throw new InvalidOperationException(
                    $"The '{nameof(Protocols)}' field cannot be null");
            }
        }
    }
}
