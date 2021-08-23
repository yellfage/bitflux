using System;

namespace Yellfage.Wst.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public abstract class AbstractAuthorizationFilterAttribute : Attribute
    {
    }
}
