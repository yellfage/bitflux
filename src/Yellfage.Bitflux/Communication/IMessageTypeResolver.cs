using System;

namespace Yellfage.Bitflux.Communication
{
    public interface IMessageTypeResolver<TMarker>
    {
        Type Resolve(IncomingMessage? message);
    }
}
