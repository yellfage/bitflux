using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yellfage.Wst
{
    public interface IClientManager<T>
    {
        IList<IClient<T>> All { get; }

        Task NotifyManyAsync(IEnumerable<IClient<T>> clients, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyManyAsync<TArg1>(IEnumerable<IClient<T>> clients, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default);
        Task NotifyManyAsync<TArg1, TArg2>(IEnumerable<IClient<T>> clients, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default);
        Task NotifyManyAsync<TArg1, TArg2, TArg3>(IEnumerable<IClient<T>> clients, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default);
        Task NotifyManyAsync<TArg1, TArg2, TArg3, TArg4>(IEnumerable<IClient<T>> clients, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default);
        Task NotifyManyAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IEnumerable<IClient<T>> clients, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default); Task NotifyManyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IEnumerable<IClient<T>> clients, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default);
        Task NotifyManyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IEnumerable<IClient<T>> clients, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default);
        Task NotifyManyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IEnumerable<IClient<T>> clients, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default);
        Task NotifyManyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IEnumerable<IClient<T>> clients, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default);
        Task NotifyManyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IEnumerable<IClient<T>> clients, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default);
        Task NotifyManyAsync(IEnumerable<IClient<T>> clients, string handlerName, object?[] args, CancellationToken cancellationToken = default);

        Task NotifyManyExceptAsync(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArg1>(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArg1, TArg2>(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArg1, TArg2, TArg3>(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4>(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default);

        Task NotifyManyExceptAsync(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArg1>(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArg1, TArg2>(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArg1, TArg2, TArg3>(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4>(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default);
        Task NotifyManyExceptAsync(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default);

        Task NotifyAllAsync(string handlerName, CancellationToken cancellationToken = default);
        Task NotifyAllAsync<TArg1>(string handlerName, TArg1 arg1, CancellationToken cancellationToken = default);
        Task NotifyAllAsync<TArg1, TArg2>(string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default);
        Task NotifyAllAsync<TArg1, TArg2, TArg3>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default);
        Task NotifyAllAsync<TArg1, TArg2, TArg3, TArg4>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default);
        Task NotifyAllAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default);
        Task NotifyAllAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default);
        Task NotifyAllAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default);
        Task NotifyAllAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default);
        Task NotifyAllAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default);
        Task NotifyAllAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default);
        Task NotifyAllAsync(string handlerName, object?[] args, CancellationToken cancellationToken = default);

        Task NotifyAllExceptAsync(IClient<T> excluded, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArg1>(IClient<T> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArg1, TArg2>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArg1, TArg2, TArg3>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync(IClient<T> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default);

        Task NotifyAllExceptAsync(IEnumerable<IClient<T>> excluded, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArg1>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArg1, TArg2>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArg1, TArg2, TArg3>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default);
        Task NotifyAllExceptAsync(IEnumerable<IClient<T>> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default);
    }
}
