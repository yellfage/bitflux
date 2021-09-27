using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yellfage.Wst.Communication.Protocol.NewtonsoftJson
{
    public class NewtonsoftJsonProtocolOptions
    {
        public JsonSerializerSettings SerializerSettings { get; set; }

        public NewtonsoftJsonProtocolOptions()
        {
            SerializerSettings = new()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy
                    {
                        ProcessDictionaryKeys = false,
                        OverrideSpecifiedNames = true
                    }
                }
            };
        }
    }
}
