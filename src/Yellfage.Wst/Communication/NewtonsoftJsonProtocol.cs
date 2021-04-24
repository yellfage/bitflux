using System;
using System.Text;
using System.Diagnostics.CodeAnalysis;
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
                ContractResolver = new CamelCasePropertyNamesContractResolver()
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

        public bool TryDeserialize(
            ArraySegment<byte> bytes,
            [MaybeNullWhen(false)] out IncomingMessage message)
        {
            try
            {
                var jObject = JObject.Parse(Encoding.UTF8.GetString(bytes));

                message = jObject.ToObject<IncomingMessage>();

                switch (message!.Type)
                {
                    case IncomingMessageType.RegularInvocation:
                        message = jObject.ToObject<IncomingRegularInvocationMessage>()!;

                        break;

                    case IncomingMessageType.NotifiableInvocation:
                        message = jObject.ToObject<IncomingNotifiableInvocationMessage>()!;

                        break;

                    default:
                        break;
                };

                return true;
            }
            catch
            {
                message = null;

                return false;
            }
        }

        public bool TryConvertValue(
            object? value,
            Type type,
            [MaybeNullWhen(false)] out object? convertedValue)
        {
            try
            {
                JToken jToken = value switch
                {
                    null => JValue.CreateNull(),
                    _ => JToken.FromObject(value)
                };

                convertedValue = jToken.ToObject(type);

                return true;
            }
            catch
            {
                convertedValue = null;

                return false;
            }
        }
    }
}
