using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Yellfage.Wst.Filtration;

namespace Yellfage.Wst.Interior.Filtration
{
    internal class FilterScreener : IFilterScreener
    {
        public IEnumerable<IFilter> Screen(MemberInfo member, IEnumerable<IFilter> filters)
        {
            IEnumerable<Type> disabledFilterTypes = member
                .GetCustomAttributes<DisableFilterAttribute>()
                .Select(attribute => attribute.Type);

            return filters
                .Where(filter => !disabledFilterTypes
                    .Any(type => type.IsAssignableFrom(filter.GetType())));
        }
    }
}
