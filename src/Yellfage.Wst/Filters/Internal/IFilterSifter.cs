using System;
using System.Collections.Generic;

namespace Yellfage.Wst.Filters.Internal
{
    internal interface IFilterSifter
    {
        IEnumerable<TFilter> Sift<TFilter>(IEnumerable<IFilter> filters, IEnumerable<Type> disabledFilterTypes) where TFilter : IFilter;
    }
}
