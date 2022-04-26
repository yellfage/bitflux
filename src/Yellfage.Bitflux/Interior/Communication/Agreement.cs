using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal class Agreement<TMarker> : IAgreement<TMarker>
    {
        public ITransport<TMarker> Transport { get; }
        public IProtocol<TMarker> Protocol { get; }

        public Agreement(ITransport<TMarker> transport, IProtocol<TMarker> protocol)
        {
            Transport = transport;
            Protocol = protocol;
        }

        public void Dispose()
        {
            Transport.Dispose();
        }
    }
}
