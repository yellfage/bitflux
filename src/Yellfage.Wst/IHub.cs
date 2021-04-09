namespace Yellfage.Wst
{
    public interface IHub<T>
    {
        IHubClientManager<T> Clients { get; }
        IHubGroupManager<T> Groups { get; }
        IHubMetadataManager<T> Metadata { get; }
    }
}
