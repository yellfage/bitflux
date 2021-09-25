using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Yellfage.Wst.Caching;

namespace Yellfage.Wst
{
    public interface IClient<TMarker>
    {
        string Id { get; }
        string Ip { get; }
        IDictionary<object, object> Records { get; }
        IClientClaimsPrincipal User { get; }
        IClientCache<TMarker> Cache { get; }

        Task DisconnectAsync(CancellationToken cancellationToken = default);
        Task DisconnectAsync(string reason, CancellationToken cancellationToken = default);

        Task NotifyAsync(string handlerName, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArgument1>(string handlerName, TArgument1 argument1, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArgument1, TArgument2>(string handlerName, TArgument1 argument1, TArgument2 argument2, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArgument1, TArgument2, TArgument3>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArgument1, TArgument2, TArgument3, TArgument4>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, CancellationToken cancellationToken = default); Task NotifyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(string handlerName, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10, CancellationToken cancellationToken = default);
        Task NotifyAsync(string handlerName, object?[] argumentuments, CancellationToken cancellationToken = default);
    }
}
