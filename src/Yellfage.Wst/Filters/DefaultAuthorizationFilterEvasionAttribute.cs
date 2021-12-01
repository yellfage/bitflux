using System;

namespace Yellfage.Wst.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public abstract class DefaultAuthorizationFilterEvasionAttribute : FilterEvasionAttribute
    {
        public DefaultAuthorizationFilterEvasionAttribute() : base(typeof(DefaultAuthorizationFilterAttribute))
        {
        }
    }
}
