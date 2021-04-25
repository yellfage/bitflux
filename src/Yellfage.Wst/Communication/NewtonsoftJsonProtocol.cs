using System;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Yellfage.Wst.Communication
{
    public class NewtonsoftJsonProtocol : IProtocol
    {
        public string Name { get; }
        public TransferFormat TransferFormat { get; }

        private JsonSerializerSettings SerializerSettings { get; }

        public NewtonsoftJsonProtocol() : this(
            new()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            })
        {
        }

        public NewtonsoftJsonProtocol(JsonSerializerSettings serializerSettings)
        {
            Name = "yellfage.wst.json";
            TransferFormat = TransferFormat.Text;
            SerializerSettings = serializerSettings;
        }

        public ArraySegment<byte> Serialize(object value)
        {
            return Encoding.UTF8.GetBytes(
                JsonConvert.SerializeObject(value, SerializerSettings));
        }

        public IncomingMessage Deserialize(ArraySegment<byte> bytes, IMessageTypeResolver messageTypeResolver)
        {
            var jObject = JObject.Parse(Encoding.UTF8.GetString(bytes));

            Type messageType = messageTypeResolver.Resolve(jObject.ToObject<IncomingMessage>()!);

            return (IncomingMessage)jObject.ToObject(messageType)!;
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
