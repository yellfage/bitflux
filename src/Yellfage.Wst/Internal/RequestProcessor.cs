using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using Yellfage.Wst.Communication;
using Yellfage.Wst.Filters.Internal;
using Yellfage.Wst.Communication.Internal;

namespace Yellfage.Wst.Internal
{
    internal class RequestProcessor<T> : IRequestProcessor
    {
        private IHub<T> Hub { get; }
        private IProtocolProvider ProtocolProvider { get; }
        private IFilterProvider FilterProvider { get; }
        private IFilterExecutor FilterExecutor { get; }
        private IHandlerDescriptorProvider HandlerDescriptorProvider { get; }
        private IHandlerExecutor HandlerExecutor { get; }
        private IServiceProvider ServiceProvider { get; }
        private HubOptions HubOptions { get; }

        public RequestProcessor(
            IHub<T> hub,
            IProtocolProvider protocolProvider,
            IFilterProvider filterProvider,
            IFilterExecutor filterExecutor,
            IHandlerDescriptorProvider handlerDescriptorProvider,
            IHandlerExecutor handlerExecutor,
            IServiceProvider serviceProvider,
            HubOptions hubOptions)
        {
            Hub = hub;
            ProtocolProvider = protocolProvider;
            FilterProvider = filterProvider;
            FilterExecutor = filterExecutor;
            HandlerDescriptorProvider = handlerDescriptorProvider;
            HandlerExecutor = handlerExecutor;
            ServiceProvider = serviceProvider;
            HubOptions = hubOptions;
        }

        public async Task ProcessAsync(HttpContext context, Func<Task> _)
        {
            if (!context.WebSockets.IsWebSocketRequest)
            {
                context.Response.StatusCode = StatusCodes.Status200OK;

                return;
            }

            if (ProtocolProvider.TryGet(
                context.WebSockets.WebSocketRequestedProtocols,
                out IProtocol? protocol))
            {
                WebSocket webSocket = await context
                    .WebSockets
                    .AcceptWebSocketAsync(protocol.Name);

                var messageTransmitter = new MessageTransmitter(webSocket, protocol);
                var clientDisconnector = new ClientDisconnector(webSocket);

                var client = new Client<T>(messageTransmitter, clientDisconnector);

                var messageReceiver = new MessageReceiver(
                    webSocket,
                    HubOptions.MessageSegmentSize,
                    HubOptions.MessageSegmentSize * HubOptions.MaxMessageSegments);

                var messageDeserializer = new MessageDeserializer(protocol);

                var argumentConverter = new ArgumentConverter(protocol);

                var invocationProcessor = new InvocationProcessor(
                    HandlerDescriptorProvider,
                    argumentConverter,
                    FilterExecutor,
                    HandlerExecutor);

                var messageDispatcher = new MessageDispatcher<T>(
                    Hub,
                    client,
                    messageReceiver,
                    messageDeserializer,
                    messageTransmitter,
                    invocationProcessor,
                    ServiceProvider);

                var connectionProcessor = new ConnectionProcessor<T>(
                    Hub,
                    client,
                    FilterProvider,
                    FilterExecutor,
                    messageDispatcher,
                    ServiceProvider);

                await connectionProcessor.StartProcessingAsync();
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;

                return;
            }
        }
    }
}
