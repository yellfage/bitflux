using System;

namespace Yellfage.Wst.Validation
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public abstract class AbstractValidationFilterAttribute : Attribute
    {
    }
}
