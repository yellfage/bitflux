using System;

namespace Yellfage.Bitflux.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class FilterEvasionAttribute : Attribute
    {
        public Type Type { get; }

        public FilterEvasionAttribute(Type type)
        {
            Type = type;
        }
    }
}
