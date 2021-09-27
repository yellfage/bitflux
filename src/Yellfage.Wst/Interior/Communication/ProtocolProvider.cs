using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal class ProtocolProvider : IProtocolProvider
    {
        private IEnumerable<IProtocol> Protocols { get; }

        public ProtocolProvider(IEnumerable<IProtocol> protocols)
        {
            Protocols = protocols;
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
