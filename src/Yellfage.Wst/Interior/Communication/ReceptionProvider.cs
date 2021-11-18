using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Interior.Communication
{
    internal class ReceptionProvider<TMarker> : IReceptionProvider<TMarker>
    {
        private IEnumerable<IReception<TMarker>> Receptions { get; }

        public ReceptionProvider(IEnumerable<IReception<TMarker>> receptions)
        {
            Receptions = receptions;
        }

        public IEnumerable<IReception<TMarker>> GetAll()
        {
            return Receptions;
        }

        public bool TryGet(
            string transportName,
            [MaybeNullWhen(false)] out IReception<TMarker> reception)
        {
            reception = Receptions
                .FirstOrDefault(reception => reception.TransportName == transportName);

            return reception is not null;
        }
    }
}
