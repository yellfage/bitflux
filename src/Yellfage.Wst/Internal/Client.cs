using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Internal
{
    internal class Client<T> : IClient<T>
    {
        public HttpContext HttpContext { get; }

        private IMessageTransmitter MessageTransmitter { get; }
        private IClientDisconnector ClientDisconnector { get; }

        public Client(
            HttpContext httpContext,
            IMessageTransmitter messageTransmitter,
            IClientDisconnector clientDisconnector)
        {
            HttpContext = httpContext;
            MessageTransmitter = messageTransmitter;
            ClientDisconnector = clientDisconnector;
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
            if (handlerName is null)
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            var message = new OutgoingNotifiableInvocationMessage(handlerName, args);

            await MessageTransmitter.TransmitAsync(message, cancellationToken);
        }

        public async Task DisconnectAsync(CancellationToken cancellationToken = default)
        {
            await DisconnectAsync("", cancellationToken);
        }

        public async Task DisconnectAsync(string reason, CancellationToken cancellationToken = default)
        {
            await ClientDisconnector.DisconnectAsync(reason, cancellationToken);
        }
    }
}
