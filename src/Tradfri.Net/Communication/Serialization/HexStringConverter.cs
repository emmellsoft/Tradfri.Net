using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Tradfri.Net.Communication.Serialization
{
    public class HexStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                writer.WriteRawValue($"\"{((int)value):x6}\"");
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            return int.Parse(reader.Value.ToString(), NumberStyles.HexNumber);
        }
    }
}
