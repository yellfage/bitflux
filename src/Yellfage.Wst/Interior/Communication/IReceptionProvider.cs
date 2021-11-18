using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IReceptionProvider<TMarker>
    {
        IEnumerable<IReception<TMarker>> GetAll();
        bool TryGet(string transportName, [MaybeNullWhen(false)] out IReception<TMarker> reception);
    }
}
