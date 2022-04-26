using System;

namespace Yellfage.Bitflux.Communication
{
    public interface IAgreement<TMarker> : IDisposable
    {
        ITransport<TMarker> Transport { get; }
        IProtocol<TMarker> Protocol { get; }
    }
}
