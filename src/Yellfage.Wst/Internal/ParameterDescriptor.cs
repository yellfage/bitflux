using System.Reflection;

namespace Yellfage.Wst.Internal
{
    internal class ParameterDescriptor
    {
        public ParameterInfo Info { get; }
        public bool IsFlexible { get; }

        public ParameterDescriptor(ParameterInfo info)
        {
            Info = info;
            IsFlexible = info.IsFlexible();
        }
    }
}
