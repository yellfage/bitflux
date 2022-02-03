namespace Yellfage.Bitflux
{
    public abstract class GroupEvent<TMarker>
    {
        public IGroupManager<TMarker> Target { get; }
        public string GroupName { get; }

        public GroupEvent(IGroupManager<TMarker> target, string groupName)
        {
            Target = target;
            GroupName = groupName;
        }
    }
}
