using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Yellfage.Wst.Communication.Internal
{
    internal class ProtocolProvider : IProtocolProvider
    {
        private IEnumerable<IProtocol> Protocols { get; }

        public ProtocolProvider(IEnumerable<IProtocol> protocols)
        {
            Protocols = protocols;
        }

        public bool TryGet(
            IEnumerable<string> protocolNames,
            [MaybeNullWhen(false)] out IProtocol protocol)
        {
            protocol = Protocols
                    .FirstOrDefault(protocol =>
                        protocolNames.Contains(protocol.Name));

            return protocol is not null;
        }
    }
}
