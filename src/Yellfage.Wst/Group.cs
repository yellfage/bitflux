using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Yellfage.Wst.Internal;

namespace Yellfage.Wst
{
    public class Group<T> : IGroup<T>
    {
        public IGroupClientManager<T> Clients { get; }
        public IGroupMetadataManager<T> Metadata { get; }

        public Group()
        {
            Clients = new GroupClientManager<T>(new Dictionary<string, IClient<T>>());
            Metadata = new GroupMetadataManager<T>(new Dictionary<string, object>());
        }

        public async Task NotifyAsync(string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(handlerName, Array.Empty<object>(), cancellationToken);
        }

        public async Task NotifyAsync<TArg1>(string handlerName, TArg1 arg1, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(handlerName, new object?[] { arg1 }, cancellationToken);
        }

        public async Task NotifyAsync<TArg1, TArg2>(string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(handlerName, new object?[] { arg1, arg2 }, cancellationToken);
        }

        public async Task NotifyAsync<TArg1, TArg2, TArg3>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(handlerName, new object?[] { arg1, arg2, arg3 }, cancellationToken);
        }

        public async Task NotifyAsync<TArg1, TArg2, TArg3, TArg4>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(handlerName, new object?[] { arg1, arg2, arg3, arg4 }, cancellationToken);
        }

        public async Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5 }, cancellationToken);
        }

        public async Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6 }, cancellationToken);
        }

        public async Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }, cancellationToken);
        }

        public async Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }, cancellationToken);
        }

        public async Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }, cancellationToken);
        }

        public async Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }, cancellationToken);
        }

        public async Task NotifyAsync(string handlerName, object?[] args, CancellationToken cancellationToken = default)
        {
            await Clients.NotifyAllAsync(
                handlerName,
                args,
                cancellationToken);
        }

        public async Task NotifyExceptAsync(IClient<T> excluded, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, Array.Empty<object>(), cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1>(IClient<T> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, new object?[] { arg1 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, new object?[] { arg1, arg2 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }, cancellationToken);
        }

        public async Task NotifyExceptAsync(IClient<T> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default)
        {
            await Clients.NotifyAllExceptAsync(
                excluded,
                handlerName,
                args,
                cancellationToken);
        }

        public async Task NotifyExceptAsync(IEnumerable<IClient<T>> excluded, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, Array.Empty<object>(), cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, new object?[] { arg1 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, new object?[] { arg1, arg2 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }, cancellationToken);
        }

        public async Task NotifyExceptAsync(IEnumerable<IClient<T>> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default)
        {
            await Clients.NotifyAllExceptAsync(
                excluded,
                handlerName,
                args,
                cancellationToken);
        }
    }
}
