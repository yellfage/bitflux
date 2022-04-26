namespace Yellfage.Bitflux.Communication
{
    public interface IAgreementFactory<TMarker>
    {
        IAgreement<TMarker> Create(ITransport<TMarker> transport, IProtocol<TMarker> protocol);
    }
}
