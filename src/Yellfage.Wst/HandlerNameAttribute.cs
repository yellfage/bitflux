using System;

namespace Yellfage.Wst
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class HandlerNameAttribute : Attribute
    {
        public string Name { get; }

        public HandlerNameAttribute(string name)
        {
            Name = name;
        }
    }
}
