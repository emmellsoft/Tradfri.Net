using System;
using Tradfri.Net.Communication.Objects;

namespace Tradfri.Net.Communication.Serialization
{
    internal class TradfriAttributeAttribute : Attribute
    {
        public TradfriAttributeAttribute(TradfriAttribute value, TradfriAttributeType type = TradfriAttributeType.Default)
        {
            Value = value;
            Type = type;
        }

        public TradfriAttributeAttribute(int value)
        {
            Value = (TradfriAttribute)value;
        }

        public TradfriAttribute Value { get; }

        public TradfriAttributeType Type { get; }
    }
}
