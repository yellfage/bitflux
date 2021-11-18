using System.Collections.Generic;

namespace Yellfage.Wst.Interior.Communication
{
    internal class AgreementFactory<TMarker> : IAgreementFactory<TMarker>
    {
        public IAgreement Create(
            IVersion version,
            IEnumerable<string> transports,
            IEnumerable<string> protocols)
        {
            return new Agreement(version, transports, protocols);
        }
    }
}
