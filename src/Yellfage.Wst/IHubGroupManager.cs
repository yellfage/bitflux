using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yellfage.Wst
{
    public interface IHubGroupManager<T>
    {
        IDictionary<string, IGroup<T>> All { get; }

        Task NotifyAsync(string groupName, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArg1>(string groupName, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArg1, TArg2>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArg1, TArg2, TArg3>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArg1, TArg2, TArg3, TArg4>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default);
        Task NotifyAsync(string groupName, string handlerName, object?[] args, CancellationToken cancellationToken = default);

        Task NotifyExceptAsync(string groupName, IClient<T> excluded, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync(string groupName, IClient<T> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default);

        Task NotifyExceptAsync(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default);
    }
}
