namespace Yellfage.Wst.Interior
{
    internal interface IGroupManagerFactory
    {
        IGroupManager<TMarker> Create<TMarker>();
    }
}
