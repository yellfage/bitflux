using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Yellfage.Bitflux.Filters;

namespace Yellfage.Bitflux.Interior.Filters
{
    internal class FilterResearcher<TMarker> : IFilterResearcher<TMarker>
    {
        public IEnumerable<IFilter> Research(MemberInfo member, IEnumerable<IFilter> outerFilters)
        {
            IEnumerable<Type> evasiveFilterTypes = member
                .GetCustomAttributes()
                .OfType<FilterEvasionAttribute>()
                .Select(attribute => attribute.Type);

            return outerFilters
                .Concat(member.GetCustomAttributes().OfType<IFilter>())
                .Where(filter => !evasiveFilterTypes
                    .Any(type => type.IsAssignableFrom(filter.GetType())));
        }
    }
}
