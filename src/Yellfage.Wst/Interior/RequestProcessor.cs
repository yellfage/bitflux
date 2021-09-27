using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Yellfage.Wst.Caching;
using Yellfage.Wst.Communication;
using Yellfage.Wst.Interior.Communication;
using Yellfage.Wst.Interior.Connection;
using Yellfage.Wst.Interior.Disconnection;
using Yellfage.Wst.Interior.Invocation;

namespace Yellfage.Wst.Interior
{
    internal class RequestProcessor : IRequestProcessor
    {
        private IProtocolProvider ProtocolProvider { get; }
        private IMessageTransmitterFactory MessageTransmitterFactory { get; }
        private IClientDisconnectorFactory ClientDisconnectorFactory { get; }
        private IClientCacheFactory ClientCacheFactory { get; }
        private IClientFactory ClientFactory { get; }
        private IMessageDeserializerFactory MessageDeserializerFactory { get; }
        private IMessageReceiverFactory MessageReceiverFactory { get; }
        private IArgumentConverterFactory ArgumentConverterFactory { get; }
        private IMessageDispatcherFactory MessageDispatcherFactory { get; }
        private IInvocationProcessorFactory InvocationProcessorFactory { get; }
        private IConnectionProcessorFactory ConnectionProcessorFactory { get; }

        public RequestProcessor(
            IProtocolProvider protocolProvider,
            IMessageTransmitterFactory messageTransmitterFactory,
            IClientDisconnectorFactory clientDisconnectorFactory,
            IClientCacheFactory clientCacheFactory,
            IClientFactory clientFactory,
            IMessageDeserializerFactory messageDeserializerFactory,
            IMessageReceiverFactory messageReceiverFactory,
            IArgumentConverterFactory argumentConverterFactory,
            IMessageDispatcherFactory messageDispatcherFactory,
            IInvocationProcessorFactory invocationProcessorFactory,
            IConnectionProcessorFactory connectionProcessorFactory)
        {
            ProtocolProvider = protocolProvider;
            MessageTransmitterFactory = messageTransmitterFactory;
            ClientDisconnectorFactory = clientDisconnectorFactory;
            ClientCacheFactory = clientCacheFactory;
            ClientFactory = clientFactory;
            MessageDeserializerFactory = messageDeserializerFactory;
            MessageReceiverFactory = messageReceiverFactory;
            ArgumentConverterFactory = argumentConverterFactory;
            MessageDispatcherFactory = messageDispatcherFactory;
            InvocationProcessorFactory = invocationProcessorFactory;
            ConnectionProcessorFactory = connectionProcessorFactory;
        }

        public async Task ProcessAsync<TMarker>(HttpContext context)
        {
            if (!context.WebSockets.IsWebSocketRequest)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;

                return;
            }

            if (ProtocolProvider.TryChoose(
                context.WebSockets.WebSocketRequestedProtocols,
                out IProtocol? protocol))
            {
                await StartAsync<TMarker>(context, protocol);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                await context.Response.WriteAsync(
                    "Unable to upgrade the connection: " +
                    "none of the provided protocols are supported");
            }
        }

        private async Task StartAsync<TMarker>(HttpContext context, IProtocol protocol)
        {
            using WebSocket webSocket = await context
                    .WebSockets
                    .AcceptWebSocketAsync(protocol.Name);

            IClientClaimsPrincipal user = new ClientClaimsPrincipal(context.User);

            IMessageTransmitter messageTransmitter = MessageTransmitterFactory
                .Create(webSocket, protocol);

            IClientDisconnector clientDisconnector = ClientDisconnectorFactory
                .Create(webSocket);

            IClientCache<TMarker> clientCache = ClientCacheFactory
                .Create<TMarker>(user);

            IClient<TMarker> client = ClientFactory
                .Create(
                    context.Connection.Id,
                    context.Connection.RemoteIpAddress?.ToString() ?? "",
                    context.Request.Headers["User-Agent"],
                    new Dictionary<object, object>(),
                    user,
                    clientCache,
                    messageTransmitter,
                    clientDisconnector);

            IMessageDeserializer messageDeserializer = MessageDeserializerFactory
                .Create(protocol);

            IMessageReceiver messageReceiver = MessageReceiverFactory
                .Create<TMarker>(webSocket, messageDeserializer);

            IArgumentConverter argumentConverter = ArgumentConverterFactory.
                Create(protocol);

            IInvocationProcessor invocationProcessor = InvocationProcessorFactory
                .Create(argumentConverter);

            IMessageDispatcher messageDispatcher = MessageDispatcherFactory
                .Create(client, messageReceiver, messageTransmitter, invocationProcessor);

            IConnectionProcessor connectionProcessor = ConnectionProcessorFactory
                .Create(client, messageDispatcher);

            await connectionProcessor.StartProcessingAsync();
        }
    }
}
