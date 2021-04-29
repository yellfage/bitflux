using System;

namespace Yellfage.Wst.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class DisableFilterAttribute : Attribute
    {
        public Type Type { get; set; }

        public DisableFilterAttribute(Type type)
        {
            if (!typeof(IFilter).IsAssignableFrom(type))
            {
                throw new ArgumentException(
                    $"The type '{type.FullName}' must derive from " +
                    $"'{typeof(IFilter).FullName}'");
            }

            Type = type;
        }
    }
}
