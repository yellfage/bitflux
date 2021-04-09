using System.Collections.Generic;

namespace Yellfage.Wst.Internal
{
    internal class GroupClientManager<T> : ClientManager<T>, IGroupClientManager<T>
    {
        public GroupClientManager(IList<IClient<T>> clients) : base(clients)
        {
        }
    }
}
