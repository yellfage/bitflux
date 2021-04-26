using System.Reflection;

namespace Yellfage.Wst.Internal
{
    internal class ParameterDescriptor
    {
        public ParameterInfo Info { get; }

        public ParameterDescriptor(ParameterInfo info)
        {
            Info = info;
        }
    }
}
