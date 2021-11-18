using System.Collections.Generic;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IAgreementFactory<TMarker>
    {
        IAgreement Create(IVersion version, IEnumerable<string> transportNames, IEnumerable<string> protocolNames);
    }
}
