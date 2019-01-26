using Newtonsoft.Json;

namespace Tradfri.Net.Communication.Serialization
{
    internal static class Json
    {
        private const string DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'ffffff'Z'";

        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new TradfriContractResolver(),
            DateFormatString = DateFormatString
        };

        private static readonly JsonSerializerSettings IgnoreNullJsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new TradfriContractResolver(),
            DateFormatString = DateFormatString,
            NullValueHandling = NullValueHandling.Ignore
        };

        private static readonly JsonSerializerSettings DebugJsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new TradfriContractResolver(false, false),
            DateFormatString = DateFormatString
        };

        public static string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value, JsonSerializerSettings);
        }

        public static string SerializeIgnoreNull(object value)
        {
            return JsonConvert.SerializeObject(value, IgnoreNullJsonSerializerSettings);
        }

        public static string SerializeDebug(object value)
        {
            return JsonConvert.SerializeObject(value, DebugJsonSerializerSettings);
        }

        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, JsonSerializerSettings);
        }
    }
}
