namespace Yellfage.Bitflux.Interior.Invocation
{
    internal interface IArgumentBinderFactory<TMarker>
    {
        IArgumentBinder<TMarker> Create(IArgumentConverter<TMarker> argumentConverter);
    }
}
