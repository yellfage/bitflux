using System;

namespace Yellfage.Wst.Communication
{
    public interface IMessageTypeResolver<TMarker>
    {
        Type Resolve(IncomingMessage? message);
    }
}
