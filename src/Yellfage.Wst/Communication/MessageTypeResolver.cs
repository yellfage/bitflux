using System;

namespace Yellfage.Wst.Communication
{
    public class MessageTypeResolver : IMessageTypeResolver
    {
        public Type Resolve(IncomingMessage message)
        {
            return message.Type switch
            {
                IncomingMessageType.RegularInvocation => typeof(IncomingRegularInvocationMessage),
                IncomingMessageType.NotifiableInvocation => typeof(IncomingNotifiableInvocationMessage),
                _ => typeof(IncomingMessage)
            };
        }
    }
}
