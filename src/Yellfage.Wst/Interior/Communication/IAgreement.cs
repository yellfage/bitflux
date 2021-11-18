using System.Collections.Generic;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IAgreement
    {
        IVersion Version { get; }
        IEnumerable<string> TransportNames { get; }
        IEnumerable<string> ProtocolNames { get; }
    }
}
