using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using Yellfage.Wst.Filtration;
using Yellfage.Wst.Interior.Filtration;

namespace Yellfage.Wst.Interior.Mapping
{
    internal abstract class Mapper
    {
        private IFilterScreener FilterScreener { get; }
        private IFilterExplorer FilterExplorer { get; }

        public Mapper(IFilterScreener filterScreener, IFilterExplorer filterExplorer)
        {
            FilterScreener = filterScreener;
            FilterExplorer = filterExplorer;
        }

        protected IEnumerable<IFilter> ResolveFilters(MemberInfo member)
        {
            return ResolveFilters(member, new IFilter[] { });
        }

        protected IEnumerable<IFilter> ResolveFilters(
            MemberInfo member,
            IEnumerable<IFilter> outerFilters)
        {
            return FilterScreener
                .Screen(member, outerFilters)
                .Concat(FilterExplorer.Explore(member));
        }
    }
}
