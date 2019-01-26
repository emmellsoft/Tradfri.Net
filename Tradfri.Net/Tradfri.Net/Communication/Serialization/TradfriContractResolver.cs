using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace Tradfri.Net.Communication.Serialization
{
    internal class TradfriContractResolver : DefaultContractResolver
    {
        private static readonly JsonConverter UnixEpochSecondsConverter = new UnixDateTimeConverter();
        private static readonly JsonConverter HexStringConverter = new HexStringConverter();
        private static readonly JsonConverter StringEnumConverter = new StringEnumConverter();
        private readonly bool _translateNames;
        private readonly bool _enumAsNumbers;

        public TradfriContractResolver(bool translateNames = true, bool enumAsNumbers = true)
        {
            _translateNames = translateNames;
            _enumAsNumbers = enumAsNumbers;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            var attribute = member.GetCustomAttribute<TradfriAttributeAttribute>();
            if (attribute != null)
            {
                property.PropertyName = _translateNames
                    ? ((int)attribute.Value).ToString()
                    : $"{(int)attribute.Value}`{property.PropertyName}`";

                switch (attribute.Type)
                {
                    case TradfriAttributeType.UnixEpochSeconds:
                        property.Converter = UnixEpochSecondsConverter;
                        break;

                    case TradfriAttributeType.HexString:
                        property.Converter = HexStringConverter;
                        break;

                    default:
                        if (!_enumAsNumbers && (member is PropertyInfo propertyInfo) && (propertyInfo.PropertyType.IsEnum))
                        {
                            property.Converter = StringEnumConverter;
                        }
                        break;
                }
            }

            return property;
        }
    }
}
