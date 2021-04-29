using System;
using System.Linq;
using System.Collections.Generic;

namespace Yellfage.Wst.Filters.Internal
{
    internal class FilterSifter : IFilterSifter
    {
        public IEnumerable<TFilter> Sift<TFilter>(
            IEnumerable<IFilter> filters,
            IEnumerable<Type> disabledFilterTypes) where TFilter : IFilter
        {
            return filters
                .Where(filter => !disabledFilterTypes.Contains(filter.GetType()))
                .OfType<TFilter>();
        }
    }
}
