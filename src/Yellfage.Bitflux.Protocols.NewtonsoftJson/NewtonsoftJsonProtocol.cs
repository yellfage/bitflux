using System;
using System.Text;

using Microsoft.Extensions.Options;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Yellfage.Bitflux.Communication;

namespace Yellfage.Bitflux.Protocols.NewtonsoftJson
{
    public class NewtonsoftJsonProtocol<TMarker> : IProtocol<TMarker>
    {
        public string Name { get; } = "json";
        public TransferFormat TransferFormat { get; } = TransferFormat.Text;

        private JsonSerializerSettings SerializerSettings { get; }

        public NewtonsoftJsonProtocol(
            IOptions<NewtonsoftJsonProtocolOptions> options) : this(options.Value.SerializerSettings)
        {
        }

        public NewtonsoftJsonProtocol(JsonSerializerSettings serializerSettings)
        {
            SerializerSettings = serializerSettings;
        }

        public ArraySegment<byte> Serialize(OutgoingMessage message)
        {
            return Encoding.UTF8.GetBytes(
                JsonConvert.SerializeObject(message, SerializerSettings));
        }

        public IncomingMessage? Deserialize(
            ArraySegment<byte> bytes,
            IMessageTypeResolver<TMarker> messageTypeResolver)
        {
            var jToken = JToken.Parse(Encoding.UTF8.GetString(bytes));

            Type messageType = messageTypeResolver.Resolve(jToken.ToObject<IncomingMessage>());

            return (IncomingMessage?)jToken.ToObject(messageType);
        }

        public object? Convert(Type type, object? value)
        {
            JToken jToken = value switch
            {
                null => JValue.CreateNull(),
                _ => JToken.FromObject(value)
            };

            return jToken.ToObject(type);
        }
    }
}
