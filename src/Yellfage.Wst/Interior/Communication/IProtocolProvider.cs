using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IProtocolProvider
    {
        bool TryChoose(IEnumerable<string> names, [MaybeNullWhen(false)] out IProtocol protocol);
    }
}
