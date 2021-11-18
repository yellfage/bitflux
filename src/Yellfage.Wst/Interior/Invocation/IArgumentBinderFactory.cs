namespace Yellfage.Wst.Interior.Invocation
{
    internal interface IArgumentBinderFactory<TMarker>
    {
        IArgumentBinder<TMarker> Create(IArgumentConverter<TMarker> argumentConverter);
    }
}
