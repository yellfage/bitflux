using Yellfage.Wst.Interior.Communication;

namespace Yellfage.Wst.Interior.Invocation
{
    internal interface IInvocationProcessorFactory
    {
        IInvocationProcessor Create(IArgumentConverter argumentConverter);
    }
}
