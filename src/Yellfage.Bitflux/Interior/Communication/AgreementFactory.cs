using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal class AgreementFactory<TMarker> : IAgreementFactory<TMarker>
    {
        public IAgreement<TMarker> Create(ITransport<TMarker> transport, IProtocol<TMarker> protocol)
        {
            return new Agreement<TMarker>(transport, protocol);
        }
    }
}
