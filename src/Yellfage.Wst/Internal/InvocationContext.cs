using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yellfage.Wst.Internal
{
    internal abstract class InvocationContext<T> : IInvocationContext<T>
    {
        public IHub<T> Hub { get; }
        public IServiceProvider ServiceProvider { get; }
        public IClient<T> Caller { get; }
        public string HandlerName { get; }
        public IList<object?> Args { get; }

        public InvocationContext(
            IHub<T> hub,
            IServiceProvider serviceProvider,
            IClient<T> caller,
            string handlerName,
            IList<object?> args)
        {
            Hub = hub;
            ServiceProvider = serviceProvider;
            Caller = caller;
            HandlerName = handlerName;
            Args = args;
        }

        public abstract Task ReplyAsync(object? data, CancellationToken cancellationToken = default);

        public abstract Task ReplyErrorAsync(string error, CancellationToken cancellationToken = default);

        public async Task NotifyOthersAsync(string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, Array.Empty<object>(), cancellationToken);
        }

        public async Task NotifyOthersAsync<TArg1>(string handlerName, TArg1 arg1, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, new object?[] { arg1 }, cancellationToken);
        }

        public async Task NotifyOthersAsync<TArg1, TArg2>(string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, new object?[] { arg1, arg2 }, cancellationToken);
        }

        public async Task NotifyOthersAsync<TArg1, TArg2, TArg3>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, new object?[] { arg1, arg2, arg3 }, cancellationToken);
        }

        public async Task NotifyOthersAsync<TArg1, TArg2, TArg3, TArg4>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, new object?[] { arg1, arg2, arg3, arg4 }, cancellationToken);
        }

        public async Task NotifyOthersAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5 }, cancellationToken);
        }

        public async Task NotifyOthersAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6 }, cancellationToken);
        }

        public async Task NotifyOthersAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }, cancellationToken);
        }

        public async Task NotifyOthersAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }, cancellationToken);
        }

        public async Task NotifyOthersAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }, cancellationToken);
        }

        public async Task NotifyOthersAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default)
        {
            await NotifyOthersAsync(handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }, cancellationToken);
        }

        public async Task NotifyOthersAsync(string handlerName, object?[] args, CancellationToken cancellationToken = default)
        {
            await Hub.Clients.NotifyAllExceptAsync(Caller, handlerName, args, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync(IClient<T> excluded, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, Array.Empty<object>(), cancellationToken);
        }

        public async Task NotifyOthersExceptAsync<TArg1>(IClient<T> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, new object?[] { arg1 }, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync<TArg1, TArg2>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, new object?[] { arg1, arg2 }, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3 }, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4 }, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5 }, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6 }, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync(IClient<T> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default)
        {
            await Hub.Clients.NotifyAllExceptAsync(new[] { Caller, excluded }, handlerName, args, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync(IEnumerable<IClient<T>> excluded, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, Array.Empty<object>(), cancellationToken);
        }

        public async Task NotifyOthersExceptAsync<TArg1>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, new object?[] { arg1 }, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync<TArg1, TArg2>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, new object?[] { arg1, arg2 }, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3 }, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4 }, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5 }, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6 }, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default)
        {
            await NotifyOthersExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }, cancellationToken);
        }

        public async Task NotifyOthersExceptAsync(IEnumerable<IClient<T>> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default)
        {
            await Hub.Clients.NotifyAllExceptAsync(new[] { Caller }.Concat(excluded), handlerName, args, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync(string groupName, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, Array.Empty<object>(), cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync<TArg1>(string groupName, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, new object?[] { arg1 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync<TArg1, TArg2>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, new object?[] { arg1, arg2 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, new object?[] { arg1, arg2, arg3 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, new object?[] { arg1, arg2, arg3, arg4 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(groupName, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync(string groupName, string handlerName, object?[] args, CancellationToken cancellationToken = default)
        {
            await Hub.Groups.NotifyExceptAsync(groupName, Caller, handlerName, args, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync(IGroup<T> group, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(group, handlerName, Array.Empty<object>(), cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync<TArg1>(IGroup<T> group, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(group, handlerName, new object?[] { arg1 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync<TArg1, TArg2>(IGroup<T> group, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(group, handlerName, new object?[] { arg1, arg2 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3>(IGroup<T> group, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(group, handlerName, new object?[] { arg1, arg2, arg3 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4>(IGroup<T> group, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(group, handlerName, new object?[] { arg1, arg2, arg3, arg4 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IGroup<T> group, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(group, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IGroup<T> group, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(group, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IGroup<T> group, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(group, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IGroup<T> group, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(group, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IGroup<T> group, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(group, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IGroup<T> group, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupAsync(group, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupAsync(IGroup<T> group, string handlerName, object?[] args, CancellationToken cancellationToken = default)
        {
            await group.NotifyExceptAsync(Caller, handlerName, args, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync(string groupName, IClient<T> excluded, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, Array.Empty<object>(), cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, new object?[] { arg1 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync(string groupName, IClient<T> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default)
        {
            await Hub.Groups.NotifyExceptAsync(groupName, new[] { Caller, excluded }, handlerName, args, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync(IGroup<T> group, IClient<T> excluded, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, Array.Empty<object>(), cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1>(IGroup<T> group, IClient<T> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, new object?[] { arg1 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2>(IGroup<T> group, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, new object?[] { arg1, arg2 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3>(IGroup<T> group, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, new object?[] { arg1, arg2, arg3 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4>(IGroup<T> group, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IGroup<T> group, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IGroup<T> group, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IGroup<T> group, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IGroup<T> group, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IGroup<T> group, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IGroup<T> group, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync(IGroup<T> group, IClient<T> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default)
        {
            await group.NotifyExceptAsync(new[] { Caller, excluded }, handlerName, args, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, Array.Empty<object>(), cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, new object?[] { arg1 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default)
        {
            await Hub.Groups.NotifyExceptAsync(groupName, new[] { Caller }.Concat(excluded), handlerName, args, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, Array.Empty<object>(), cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1>(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, new object?[] { arg1 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2>(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, new object?[] { arg1, arg2 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3>(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, new object?[] { arg1, arg2, arg3 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4>(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default)
        {
            await NotifyOthersInGroupExceptAsync(group, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }, cancellationToken);
        }

        public async Task NotifyOthersInGroupExceptAsync(IGroup<T> group, IEnumerable<IClient<T>> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default)
        {
            await group.NotifyExceptAsync(new[] { Caller }.Concat(excluded), handlerName, args, cancellationToken);
        }
    }
}
