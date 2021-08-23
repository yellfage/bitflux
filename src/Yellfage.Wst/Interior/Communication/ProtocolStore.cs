using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal class ProtocolStore : IProtocolStore
    {
        private List<IProtocol> Protocols { get; }

        public ProtocolStore() : this(new List<IProtocol>())
        {
        }

        public ProtocolStore(List<IProtocol> protocols)
        {
            Protocols = protocols;
        }

        public void AddRange(IEnumerable<IProtocol> protocols)
        {
            Protocols.AddRange(protocols);
        }

        public bool TryChoose(
            IEnumerable<string> names,
            [MaybeNullWhen(false)] out IProtocol protocol)
        {
            protocol = Protocols
                    .FirstOrDefault(protocol => names.Contains(protocol.Name));

            return protocol is not null;
        }
    }
}
