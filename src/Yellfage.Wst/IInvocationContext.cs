using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Yellfage.Wst.Filters;

namespace Yellfage.Wst
{
    public interface IInvocationContext<T> : IFilterContext<T>
    {
        IClient<T> Caller { get; }
        string HandlerName { get; }
        IList<object?> Args { get; }

        Task ReplyAsync(object? payload, CancellationToken cancellationToken = default);

        Task ReplyErrorAsync(string error, CancellationToken cancellationToken = default);

        Task NotifyOthersAsync(string handlerName, CancellationToken cancellationToken = default);
        Task NotifyOthersAsync<TArg1>(string handlerName, TArg1 arg1, CancellationToken cancellationToken = default);
        Task NotifyOthersAsync<TArg1, TArg2>(string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default);
        Task NotifyOthersAsync<TArg1, TArg2, TArg3>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default);
        Task NotifyOthersAsync<TArg1, TArg2, TArg3, TArg4>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default);
        Task NotifyOthersAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default);
        Task NotifyOthersAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default);
        Task NotifyOthersAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default);
        Task NotifyOthersAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default);
        Task NotifyOthersAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default);
        Task NotifyOthersAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default);
        Task NotifyOthersAsync(string handlerName, object?[] args, CancellationToken cancellationToken = default);

        Task NotifyOthersExceptAsync(IClient<T> excluded, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync<TArg1>(IClient<T> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync<TArg1, TArg2>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync(IClient<T> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default);

        Task NotifyOthersExceptAsync(IEnumerable<IClient<T>> excluded, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync<TArg1>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync<TArg1, TArg2>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default);
        Task NotifyOthersExceptAsync(IEnumerable<IClient<T>> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default);

        Task NotifyOthersInGroupAsync(string groupName, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync<TArg1>(string groupName, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync<TArg1, TArg2>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync(string groupName, string handlerName, object?[] args, CancellationToken cancellationToken = default);

        Task NotifyOthersInGroupAsync(IGroup<T> group, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync<TArg1>(IGroup<T> group, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync<TArg1, TArg2>(IGroup<T> group, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3>(IGroup<T> group, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4>(IGroup<T> group, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IGroup<T> group, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IGroup<T> group, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IGroup<T> group, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IGroup<T> group, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IGroup<T> group, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IGroup<T> group, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupAsync(IGroup<T> group, string handlerName, object?[] args, CancellationToken cancellationToken = default);

        Task NotifyOthersInGroupExceptAsync(string groupName, IClient<T> excluded, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync(string groupName, IClient<T> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default);

        Task NotifyOthersInGroupExceptAsync(IGroup<T> group, IClient<T> excluded, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1>(IGroup<T> group, IClient<T> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2>(IGroup<T> group, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3>(IGroup<T> group, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4>(IGroup<T> group, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IGroup<T> group, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IGroup<T> group, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IGroup<T> group, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IGroup<T> group, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IGroup<T> group, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IGroup<T> group, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync(IGroup<T> group, IClient<T> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default);

        Task NotifyOthersInGroupExceptAsync(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default);

        Task NotifyOthersInGroupExceptAsync(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1>(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2>(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3>(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4>(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default);
        Task NotifyOthersInGroupExceptAsync(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default);
    }
}
