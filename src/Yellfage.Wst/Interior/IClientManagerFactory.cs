namespace Yellfage.Wst.Interior
{
    internal interface IClientManagerFactory
    {
        IClientManager<TMarker> Create<TMarker>();
    }
}
