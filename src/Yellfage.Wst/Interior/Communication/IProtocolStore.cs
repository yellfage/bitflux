using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IProtocolStore
    {
        void AddRange(IEnumerable<IProtocol> protocols);
        bool TryChoose(IEnumerable<string> names, [MaybeNullWhen(false)] out IProtocol protocol);
    }
}
