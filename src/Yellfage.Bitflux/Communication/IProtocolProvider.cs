using System.Collections.Generic;

namespace Yellfage.Bitflux.Communication
{
    public interface IProtocolProvider<TMarker>
    {
        /// <exception cref="ProtocolException" />
        IProtocol<TMarker> Select(IEnumerable<string> names);
    }
}
