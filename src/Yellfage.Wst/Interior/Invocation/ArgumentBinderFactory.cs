namespace Yellfage.Wst.Interior.Invocation
{
    internal class ArgumentBinderFactory<TMarker> : IArgumentBinderFactory<TMarker>
    {
        public IArgumentBinder<TMarker> Create(IArgumentConverter<TMarker> argumentConverter)
        {
            return new ArgumentBinder<TMarker>(argumentConverter);
        }
    }
}
