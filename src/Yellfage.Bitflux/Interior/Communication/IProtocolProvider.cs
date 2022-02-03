using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal interface IProtocolProvider<TMarker>
    {
        IEnumerable<IProtocol<TMarker>> GetAll();
        bool TryGet(string name, [MaybeNullWhen(false)] out IProtocol<TMarker> protocol);
    }
}
