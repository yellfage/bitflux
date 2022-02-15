using System.Collections.Generic;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal class Agreement : IAgreement
    {
        public IVersion Version { get; }
        public IEnumerable<string> Transports { get; }
        public IEnumerable<string> Protocols { get; }

        public Agreement(
            IVersion version,
            IEnumerable<string> transports,
            IEnumerable<string> protocols)
        {
            Version = version;
            Transports = transports;
            Protocols = protocols;
        }
    }
}
