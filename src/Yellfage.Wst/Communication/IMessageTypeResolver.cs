using System;

namespace Yellfage.Wst.Communication
{
    public interface IMessageTypeResolver
    {
        Type Resolve(IncomingMessage message);
    }
}
