using System.Collections.Generic;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal interface IAgreement
    {
        IVersion Version { get; }
        IEnumerable<string> TransportNames { get; }
        IEnumerable<string> ProtocolNames { get; }
    }
}
