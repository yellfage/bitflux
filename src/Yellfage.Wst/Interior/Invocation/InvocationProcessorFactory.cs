using Yellfage.Wst.Interior.Communication;
using Yellfage.Wst.Interior.Filtration;
using Yellfage.Wst.Interior.Handling;

namespace Yellfage.Wst.Interior.Invocation
{
    internal class InvocationProcessorFactory : IInvocationProcessorFactory
    {
        private IHandlerStore HandlerStore { get; }
        private IHandlerFilterStore HandlerFilterStore { get; }
        private IFilterExecutor FilterExecutor { get; }

        public InvocationProcessorFactory(
            IHandlerStore handlerStore,
            IHandlerFilterStore handlerFilterStore,
            IFilterExecutor filterExecutor)
        {
            HandlerStore = handlerStore;
            HandlerFilterStore = handlerFilterStore;
            FilterExecutor = filterExecutor;
        }

        public IInvocationProcessor Create(IArgumentConverter argumentConverter)
        {
            return new InvocationProcessor(
                HandlerStore,
                HandlerFilterStore,
                FilterExecutor,
                argumentConverter);
        }
    }
}
