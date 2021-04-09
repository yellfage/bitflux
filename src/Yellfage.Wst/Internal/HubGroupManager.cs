using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yellfage.Wst.Internal
{
    internal class HubGroupManager<T> : IHubGroupManager<T>
    {
        public IDictionary<string, IGroup<T>> All { get; }

        public HubGroupManager(IDictionary<string, IGroup<T>> groups)
        {
            All = groups;
        }

        public async Task NotifyAsync(string groupName, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, Array.Empty<object>(), cancellationToken);
        }

        public async Task NotifyAsync<TArg1>(string groupName, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, new object?[] { arg1 }, cancellationToken);
        }

        public async Task NotifyAsync<TArg1, TArg2>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, new object?[] { arg1, arg2 }, cancellationToken);
        }

        public async Task NotifyAsync<TArg1, TArg2, TArg3>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, new object?[] { arg1, arg2, arg3 }, cancellationToken);
        }

        public async Task NotifyAsync<TArg1, TArg2, TArg3, TArg4>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, new object?[] { arg1, arg2, arg3, arg4 }, cancellationToken);
        }

        public async Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5 }, cancellationToken);
        }

        public async Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6 }, cancellationToken);
        }

        public async Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }, cancellationToken);
        }

        public async Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }, cancellationToken);
        }

        public async Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }, cancellationToken);
        }

        public async Task NotifyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string groupName, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default)
        {
            await NotifyAsync(groupName, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }, cancellationToken);
        }

        public async Task NotifyAsync(string groupName, string handlerName, object?[] args, CancellationToken cancellationToken = default)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException(nameof(groupName));
            }

            await All[groupName].NotifyAsync(
                handlerName,
                args,
                cancellationToken);
        }

        public async Task NotifyExceptAsync(string groupName, IClient<T> excluded, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, Array.Empty<object>(), cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { arg1 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string groupName, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }, cancellationToken);
        }

        public async Task NotifyExceptAsync(string groupName, IClient<T> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException(nameof(groupName));
            }

            await All[groupName].NotifyExceptAsync(
                excluded,
                handlerName,
                args,
                cancellationToken);
        }

        public async Task NotifyExceptAsync(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, Array.Empty<object>(), cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { arg1 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }, cancellationToken);
        }

        public async Task NotifyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default)
        {
            await NotifyExceptAsync(groupName, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }, cancellationToken);
        }

        public async Task NotifyExceptAsync(string groupName, IEnumerable<IClient<T>> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException(nameof(groupName));
            }

            await All[groupName].NotifyExceptAsync(
                excluded,
                handlerName,
                args,
                cancellationToken);
        }
    }
}
