using System.Collections.Generic;

using Yellfage.Wst.Filtration;
using Yellfage.Wst.Interior.Handling;

namespace Yellfage.Wst.Interior.Filtration
{
    internal class HandlerFilterStore : IHandlerFilterStore
    {
        private IDictionary<Handler, List<IFilter>> Filters { get; }

        public HandlerFilterStore() : this(new Dictionary<Handler, List<IFilter>>())
        {
        }

        public HandlerFilterStore(IDictionary<Handler, List<IFilter>> filters)
        {
            Filters = filters;
        }

        public void AddRange(Handler handler, IEnumerable<IFilter> filters)
        {
            if (!Filters.ContainsKey(handler))
            {
                Filters.Add(handler, new List<IFilter>());
            }

            Filters[handler].AddRange(filters);
        }

        public IEnumerable<IFilter> GetAll(Handler handler)
        {
            return Filters[handler];
        }
    }
}
