using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Yellfage.Wst.Communication.Internal
{
    internal interface IProtocolProvider
    {
        bool TryGet(IEnumerable<string> protocolNames, [MaybeNullWhen(false)] out IProtocol protocol);
    }
}
