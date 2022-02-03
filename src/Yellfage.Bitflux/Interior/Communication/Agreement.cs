using System.Collections.Generic;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal class Agreement : IAgreement
    {
        public IVersion Version { get; }
        public IEnumerable<string> TransportNames { get; }
        public IEnumerable<string> ProtocolNames { get; }

        public Agreement(
            IVersion version,
            IEnumerable<string> transportNames,
            IEnumerable<string> protocolNames)
        {
            Version = version;
            TransportNames = transportNames;
            ProtocolNames = protocolNames;
        }
    }
}
