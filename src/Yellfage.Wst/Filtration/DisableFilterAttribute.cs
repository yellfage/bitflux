using System;

namespace Yellfage.Wst.Filtration
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class DisableFilterAttribute : Attribute
    {
        public Type Type { get; }

        public DisableFilterAttribute(Type type)
        {
            if (!typeof(IFilter).IsAssignableFrom(type))
            {
                throw new ArgumentException(
                    $"The '{type.FullName}' type must derive from " +
                    $"'{typeof(IFilter).FullName}'");
            }

            Type = type;
        }
    }
}
