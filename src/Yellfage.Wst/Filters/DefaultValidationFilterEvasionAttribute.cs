using System;

namespace Yellfage.Wst.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public abstract class DefaultValidationFilterEvasionAttribute : FilterEvasionAttribute
    {
        public DefaultValidationFilterEvasionAttribute() : base(typeof(DefaultValidationFilterAttribute))
        {
        }
    }
}
