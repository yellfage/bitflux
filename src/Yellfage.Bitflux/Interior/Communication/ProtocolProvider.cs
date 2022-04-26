using System.Collections.Generic;
using System.Linq;

using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal class ProtocolProvider<TMarker> : IProtocolProvider<TMarker>
    {
        private IEnumerable<IProtocol<TMarker>> Protocols { get; }

        public ProtocolProvider(IEnumerable<IProtocol<TMarker>> protocols)
        {
            Protocols = protocols;
        }

        public IProtocol<TMarker> Select(IEnumerable<string> names)
        {
            IProtocol<TMarker>? protocol = Protocols
                .FirstOrDefault(currentProtocol => names
                    .Any(name => currentProtocol.Name == name));

            if (protocol is null)
            {
                throw new ProtocolException(
                    $"None protocol with the provided names [{string.Join(", ", names)}] found");
            }

            return protocol;
        }
    }
}
