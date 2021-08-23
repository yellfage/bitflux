using System.Collections.Generic;

using Yellfage.Wst.Filtration;

namespace Yellfage.Wst.Interior.Filtration
{
    internal class HubFilterStore : IHubFilterStore
    {
        private List<IFilter> Filters { get; }

        public HubFilterStore() : this(new List<IFilter>())
        {
        }

        public HubFilterStore(List<IFilter> filters)
        {
            Filters = filters;
        }

        public void AddRange(IEnumerable<IFilter> filters)
        {
            Filters.AddRange(filters);
        }

        public IEnumerable<IFilter> GetAll()
        {
            return Filters;
        }
    }
}
