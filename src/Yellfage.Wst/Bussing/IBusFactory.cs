namespace Yellfage.Wst.Bussing
{
    public interface IBusFactory
    {
        IBus<TMarker> Create<TMarker>();
    }
}
