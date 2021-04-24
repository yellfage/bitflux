using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yellfage.Wst.Internal
{
    internal abstract class ClientManager<T> : IClientManager<T>
    {
        public IDictionary<string, IClient<T>> All { get; }

        public ClientManager(IDictionary<string, IClient<T>> clients)
        {
            All = clients;
        }

        public async Task NotifyManyAsync(IEnumerable<IClient<T>> clients, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(clients, handlerName, Array.Empty<object>(), cancellationToken);
        }

        public async Task NotifyManyAsync<TArg1>(IEnumerable<IClient<T>> clients, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(clients, handlerName, new object?[] { arg1 }, cancellationToken);
        }

        public async Task NotifyManyAsync<TArg1, TArg2>(IEnumerable<IClient<T>> clients, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(clients, handlerName, new object?[] { arg1, arg2 }, cancellationToken);
        }

        public async Task NotifyManyAsync<TArg1, TArg2, TArg3>(IEnumerable<IClient<T>> clients, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(clients, handlerName, new object?[] { arg1, arg2, arg3 }, cancellationToken);
        }

        public async Task NotifyManyAsync<TArg1, TArg2, TArg3, TArg4>(IEnumerable<IClient<T>> clients, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(clients, handlerName, new object?[] { arg1, arg2, arg3, arg4 }, cancellationToken);
        }

        public async Task NotifyManyAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IEnumerable<IClient<T>> clients, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(clients, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5 }, cancellationToken);
        }

        public async Task NotifyManyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IEnumerable<IClient<T>> clients, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(clients, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6 }, cancellationToken);
        }

        public async Task NotifyManyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IEnumerable<IClient<T>> clients, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(clients, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }, cancellationToken);
        }

        public async Task NotifyManyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IEnumerable<IClient<T>> clients, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(clients, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }, cancellationToken);
        }

        public async Task NotifyManyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IEnumerable<IClient<T>> clients, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(clients, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }, cancellationToken);
        }

        public async Task NotifyManyAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IEnumerable<IClient<T>> clients, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(clients, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }, cancellationToken);
        }

        public async Task NotifyManyAsync(IEnumerable<IClient<T>> clients, string handlerName, object?[] args, CancellationToken cancellationToken = default)
        {
            if (clients == null)
            {
                throw new ArgumentNullException(nameof(clients));
            }

            if (handlerName == null)
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            await Task.WhenAll(
                clients.Select((client) =>
                    client.NotifyAsync(handlerName, args, cancellationToken)));
        }

        public async Task NotifyManyExceptAsync(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, Array.Empty<object>(), cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArg1>(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, new object?[] { arg1 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArg1, TArg2>(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, new object?[] { arg1, arg2 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArg1, TArg2, TArg3>(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, new object?[] { arg1, arg2, arg3 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4>(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync(IEnumerable<IClient<T>> clients, IClient<T> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default)
        {
            if (excluded == null)
            {
                throw new ArgumentNullException(nameof(excluded));
            }

            await NotifyManyAsync(
                clients.Where(client => client != excluded),
                handlerName,
                args,
                cancellationToken);
        }

        public async Task NotifyManyExceptAsync(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, Array.Empty<object>(), cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArg1>(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, new object?[] { arg1 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArg1, TArg2>(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, new object?[] { arg1, arg2 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArg1, TArg2, TArg3>(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, new object?[] { arg1, arg2, arg3 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4>(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(clients, excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }, cancellationToken);
        }

        public async Task NotifyManyExceptAsync(IEnumerable<IClient<T>> clients, IEnumerable<IClient<T>> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default)
        {
            if (excluded == null)
            {
                throw new ArgumentNullException(nameof(excluded));
            }

            await NotifyManyAsync(
                All.Values.Except(excluded),
                handlerName,
                args,
                cancellationToken);
        }

        public async Task NotifyAllAsync(string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, Array.Empty<object>());
        }

        public async Task NotifyAllAsync<TArg1>(string handlerName, TArg1 arg1, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, new object?[] { arg1 }, cancellationToken);
        }

        public async Task NotifyAllAsync<TArg1, TArg2>(string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, new object?[] { arg1, arg2 }, cancellationToken);
        }

        public async Task NotifyAllAsync<TArg1, TArg2, TArg3>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, new object?[] { arg1, arg2, arg3 }, cancellationToken);
        }

        public async Task NotifyAllAsync<TArg1, TArg2, TArg3, TArg4>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, new object?[] { arg1, arg2, arg3, arg4 }, cancellationToken);
        }

        public async Task NotifyAllAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5 }, cancellationToken);
        }

        public async Task NotifyAllAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6 }, cancellationToken);
        }

        public async Task NotifyAllAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }, cancellationToken);
        }

        public async Task NotifyAllAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }, cancellationToken);
        }

        public async Task NotifyAllAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }, cancellationToken);
        }

        public async Task NotifyAllAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default)
        {
            await NotifyAllAsync(handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }, cancellationToken);
        }

        public async Task NotifyAllAsync(string handlerName, object?[] args, CancellationToken cancellationToken = default)
        {
            await NotifyManyAsync(All.Values, handlerName, args, cancellationToken);
        }

        public async Task NotifyAllExceptAsync(IClient<T> excluded, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, Array.Empty<object>(), cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArg1>(IClient<T> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { arg1 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArg1, TArg2>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { arg1, arg2 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArg1, TArg2, TArg3>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IClient<T> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync(IClient<T> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(
                All.Values,
                excluded,
                handlerName,
                args,
                cancellationToken);
        }

        public async Task NotifyAllExceptAsync(IEnumerable<IClient<T>> excluded, string handlerName, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, Array.Empty<object>(), cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArg1>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { arg1 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArg1, TArg2>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { arg1, arg2 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArg1, TArg2, TArg3>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(IEnumerable<IClient<T>> excluded, string handlerName, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, CancellationToken cancellationToken = default)
        {
            await NotifyAllExceptAsync(excluded, handlerName, new object?[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }, cancellationToken);
        }

        public async Task NotifyAllExceptAsync(IEnumerable<IClient<T>> excluded, string handlerName, object?[] args, CancellationToken cancellationToken = default)
        {
            await NotifyManyExceptAsync(
                All.Values,
                excluded,
                handlerName,
                args,
                cancellationToken);
        }
    }
}
