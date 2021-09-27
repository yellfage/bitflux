using System;
using System.Text;

using Microsoft.Extensions.Options;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Yellfage.Wst.Communication.Protocol.NewtonsoftJson
{
    public class NewtonsoftJsonProtocol : IProtocol
    {
        public string Name { get; }
        public TransferFormat TransferFormat { get; }

        private JsonSerializerSettings SerializerSettings { get; }

        public NewtonsoftJsonProtocol(
            IOptions<NewtonsoftJsonProtocolOptions> options) : this(options.Value.SerializerSettings)
        {
        }

        public NewtonsoftJsonProtocol(JsonSerializerSettings serializerSettings)
        {
            Name = "json";
            TransferFormat = TransferFormat.Text;
            SerializerSettings = serializerSettings;
        }

        public ArraySegment<byte> Serialize(OutgoingMessage message)
        {
            return Encoding.UTF8.GetBytes(
                JsonConvert.SerializeObject(message, SerializerSettings));
        }

        public IncomingMessage? Deserialize(
            ArraySegment<byte> bytes,
            IMessageTypeResolver messageTypeResolver)
        {
            var jToken = JToken.Parse(Encoding.UTF8.GetString(bytes));

            Type messageType = messageTypeResolver.Resolve(jToken.ToObject<IncomingMessage>());

            return (IncomingMessage?)jToken.ToObject(messageType);
        }

        public object? Convert(object? value, Type type)
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
