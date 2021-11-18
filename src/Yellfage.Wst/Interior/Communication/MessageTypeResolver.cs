using System;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    public class MessageTypeResolver<TMarker> : IMessageTypeResolver<TMarker>
    {
        public Type Resolve(IncomingMessage? message)
        {
            return message?.Type switch
            {
                IncomingMessageType.RegularInvocation => typeof(IncomingRegularInvocationMessage),

                IncomingMessageType.NotifiableInvocation => typeof(IncomingNotifiableInvocationMessage),

                _ => typeof(IncomingMessage)
            };
        }
    }
}
