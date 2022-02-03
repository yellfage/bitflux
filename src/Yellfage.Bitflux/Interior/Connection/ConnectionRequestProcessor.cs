using System.Collections.Concurrent;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Yellfage.Bitflux.Caching;
using Yellfage.Bitflux.Communication;
using Yellfage.Bitflux.Interior.Communication;
using Yellfage.Bitflux.Interior.Disconnection;
using Yellfage.Bitflux.Interior.Invocation;
using Yellfage.Bitflux.Interior.Notification;

namespace Yellfage.Bitflux.Interior.Connection
{
    internal class ConnectionRequestProcessor<TMarker> : IConnectionRequestProcessor<TMarker>
    {
        private IReceptionProvider<TMarker> ReceptionProvider { get; }
        private IProtocolProvider<TMarker> ProtocolProvider { get; }
        private IClientClaimsPrincipalFactory<TMarker> ClientClaimsPrincipalFactory { get; }
        private IClientCacheFactory<TMarker> ClientCacheFactory { get; }
        private IMessageTransmitterFactory<TMarker> MessageTransmitterFactory { get; }
        private IClientNotifierFactory<TMarker> ClientNotifierFactory { get; }
        private IClientDisconnectorFactory<TMarker> ClientDisconnectorFactory { get; }
        private IClientFactory<TMarker> ClientFactory { get; }
        private IMessageDeserializerFactory<TMarker> MessageDeserializerFactory { get; }
        private IMessageReceiverFactory<TMarker> MessageReceiverFactory { get; }
        private IArgumentConverterFactory<TMarker> ArgumentConverterFactory { get; }
        private IArgumentBinderFactory<TMarker> ArgumentBinderFactory { get; }
        private IHandlerExecutorFactory<TMarker> HandlerExecutorFactory { get; }
        private IRegularInvocationResponderFactory<TMarker> RegularInvocationResponderFactory { get; }
        private INotifiableInvocationResponderFactory<TMarker> NotifiableInvocationResponderFactory { get; }
        private IInvocationMessageProcessorFactory<TMarker> InvocationMessageProcessorFactory { get; }
        private IMessageDispatcherFactory<TMarker> MessageDispatcherFactory { get; }
        private IConnectionProcessorFactory<TMarker> ConnectionProcessorFactory { get; }

        public ConnectionRequestProcessor(
            IReceptionProvider<TMarker> receptionProvider,
            IProtocolProvider<TMarker> protocolProvider,
            IClientClaimsPrincipalFactory<TMarker> clientClaimsPrincipalFactory,
            IClientCacheFactory<TMarker> clientCacheFactory,
            IMessageTransmitterFactory<TMarker> messageTransmitterFactory,
            IClientNotifierFactory<TMarker> clientNotifierFactory,
            IClientDisconnectorFactory<TMarker> clientDisconnectorFactory,
            IClientFactory<TMarker> clientFactory,
            IMessageDeserializerFactory<TMarker> messageDeserializerFactory,
            IMessageReceiverFactory<TMarker> messageReceiverFactory,
            IArgumentConverterFactory<TMarker> argumentConverterFactory,
            IArgumentBinderFactory<TMarker> argumentBinderFactory,
            IHandlerExecutorFactory<TMarker> handlerExecutorFactory,
            IRegularInvocationResponderFactory<TMarker> regularInvocationResponderFactory,
            INotifiableInvocationResponderFactory<TMarker> notifiableInvocationResponderFactory,
            IInvocationMessageProcessorFactory<TMarker> invocationMessageProcessorFactory,
            IMessageDispatcherFactory<TMarker> messageDispatcherFactory,
            IConnectionProcessorFactory<TMarker> connectionProcessorFactory)
        {
            ReceptionProvider = receptionProvider;
            ProtocolProvider = protocolProvider;
            ClientClaimsPrincipalFactory = clientClaimsPrincipalFactory;
            ClientCacheFactory = clientCacheFactory;
            MessageTransmitterFactory = messageTransmitterFactory;
            ClientNotifierFactory = clientNotifierFactory;
            ClientDisconnectorFactory = clientDisconnectorFactory;
            ClientFactory = clientFactory;
            MessageDeserializerFactory = messageDeserializerFactory;
            MessageReceiverFactory = messageReceiverFactory;
            ArgumentConverterFactory = argumentConverterFactory;
            ArgumentBinderFactory = argumentBinderFactory;
            HandlerExecutorFactory = handlerExecutorFactory;
            RegularInvocationResponderFactory = regularInvocationResponderFactory;
            NotifiableInvocationResponderFactory = notifiableInvocationResponderFactory;
            InvocationMessageProcessorFactory = invocationMessageProcessorFactory;
            MessageDispatcherFactory = messageDispatcherFactory;
            ConnectionProcessorFactory = connectionProcessorFactory;
        }

        public async Task ProcessAsync(HttpContext context)
        {
            string transportName = context.Request.Query["transport"].ToString();
            string protocolName = context.Request.Query["protocol"].ToString();

            if (ReceptionProvider.TryGet(transportName, out IReception<TMarker>? reception))
            {
                if (ProtocolProvider.TryGet(protocolName, out IProtocol<TMarker>? protocol))
                {
                    try
                    {
                        await StartAsync(context, reception, protocol);
                    }
                    catch (ReceptionException exception)
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;

                        await context.Response.WriteAsync(exception.Message);

                        return;
                    }
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;

                    await context.Response.WriteAsync(
                        "Unable to process the request: " +
                        "none of the provided protocols are supported");

                    return;
                }
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                await context.Response.WriteAsync(
                    "Unable to process the request: " +
                    "none of the provided transports are supported");

                return;
            }
        }

        /// <exception cref="ReceptionException" />
        private async Task StartAsync(
            HttpContext context,
            IReception<TMarker> reception,
            IProtocol<TMarker> protocol)
        {
            using ITransport<TMarker> transport = await reception.AcceptAsync(context);

            IClientClaimsPrincipal<TMarker> user = ClientClaimsPrincipalFactory
                .Create(context.User);

            IClientCache<TMarker> clientCache = ClientCacheFactory
                .Create(user);

            IMessageTransmitter<TMarker> messageTransmitter = MessageTransmitterFactory
                .Create(transport, protocol);

            IClientNotifier<TMarker> clientNotifier = ClientNotifierFactory
                .Create(messageTransmitter);

            IClientDisconnector<TMarker> clientDisconnector = ClientDisconnectorFactory
                .Create(transport);

            IClient<TMarker> client = ClientFactory
                .Create(
                    context.Connection.Id,
                    context.Connection.RemoteIpAddress?.ToString() ?? "",
                    context.Request.Headers["User-Agent"],
                    new ConcurrentDictionary<object, object>(),
                    user,
                    clientCache,
                    clientNotifier,
                    clientDisconnector);

            IMessageDeserializer<TMarker> messageDeserializer = MessageDeserializerFactory
                .Create(protocol);

            IMessageReceiver<TMarker> messageReceiver = MessageReceiverFactory
                .Create(transport, messageDeserializer);

            IArgumentConverter<TMarker> argumentConverter = ArgumentConverterFactory.
                Create(protocol);

            IArgumentBinder<TMarker> argumentBinder = ArgumentBinderFactory
                .Create(argumentConverter);

            IHandlerExecutor<TMarker> handlerExecutor = HandlerExecutorFactory
                .Create();

            IRegularInvocationResponder<TMarker> regularInvocationResponder = RegularInvocationResponderFactory
                .Create(messageTransmitter);

            INotifiableInvocationResponder<TMarker> notifiableInvocationResponder = NotifiableInvocationResponderFactory
                .Create();

            IInvocationMessageProcessor<TMarker> invocationMessageProcessor = InvocationMessageProcessorFactory
                .Create(client, argumentBinder, handlerExecutor, regularInvocationResponder, notifiableInvocationResponder);

            IMessageDispatcher<TMarker> messageDispatcher = MessageDispatcherFactory
                .Create(invocationMessageProcessor, messageReceiver);

            IConnectionProcessor<TMarker> connectionProcessor = ConnectionProcessorFactory
                .Create(client, messageDispatcher);

            await connectionProcessor.StartAsync();
        }
    }
}
