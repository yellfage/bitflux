using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal class ProtocolProvider<TMarker> : IProtocolProvider<TMarker>
    {
        private IEnumerable<IProtocol<TMarker>> Protocols { get; }

        public ProtocolProvider(IEnumerable<IProtocol<TMarker>> protocols)
        {
            Protocols = protocols;
        }

        public IEnumerable<IProtocol<TMarker>> GetAll()
        {
            return Protocols;
        }

        public bool TryGet(string name, [MaybeNullWhen(false)] out IProtocol<TMarker> protocol)
        {
            protocol = Protocols.FirstOrDefault(protocol => protocol.Name == name);

            return protocol is not null;
        }
    }
}
