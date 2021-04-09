using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yellfage.Wst
{
    public interface IGroup<T>
    {
        IGroupClientManager<T> Clients { get; }
        IGroupMetadataManager<T> Metadata { get; }

        Task NotifyAsync(string handlerName, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArg1>(string handlerName, TArg1 arg1, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArg1, TArg2>(string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArg1, TArg2, TArg3>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArg1, TArg2, TArg3, TArg4>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default);
        Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default);
        Task NotifyAsync(string handlerName, object?[] args, CancellationToken cancellationToken = default);

        Task NotifyExceptAsync(IClient<T> excluded, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1>(IClient<T> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync(IClient<T> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default);

        Task NotifyExceptAsync(IEnumerable<IClient<T>> excluded, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default);
        Task NotifyExceptAsync(IEnumerable<IClient<T>> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default);
    }
}
