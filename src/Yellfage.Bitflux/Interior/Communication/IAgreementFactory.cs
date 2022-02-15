using System.Collections.Generic;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal interface IAgreementFactory<TMarker>
    {
        IAgreement Create(IVersion version, IEnumerable<string> transports, IEnumerable<string> protocols);
    }
}
