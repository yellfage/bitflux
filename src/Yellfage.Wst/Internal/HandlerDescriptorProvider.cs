using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Yellfage.Wst.Internal
{
    internal class HandlerDescriptorProvider : IHandlerDescriptorProvider
    {
        private IEnumerable<HandlerDescriptor> Descriptors { get; }

        public HandlerDescriptorProvider(IEnumerable<HandlerDescriptor> descriptors)
        {
            Descriptors = descriptors;
        }

        public bool TryGet(
            string name,
            [MaybeNullWhen(false)] out HandlerDescriptor handlerDescriptor)
        {
            handlerDescriptor = Descriptors
                .FirstOrDefault(descriptor => descriptor.Name == name);

            return handlerDescriptor != null;
        }
    }
}
