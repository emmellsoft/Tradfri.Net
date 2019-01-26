using Tradfri.Net.Communication.Serialization;

namespace Tradfri.Net.Communication.Objects
{
    internal class LightStatusResponse
    {
        [TradfriAttribute(TradfriAttribute.Id)]
        public int Id { get; set; }

        [TradfriAttribute(TradfriAttribute.LightState)]
        public int State { get; set; }

        [TradfriAttribute(TradfriAttribute.LightDimmer)]
        public int? Dimmer { get; set; }

        [TradfriAttribute(TradfriAttribute.LightMireds)]
        public int? Mireds { get; set; }

        [TradfriAttribute(TradfriAttribute.LightColorHex, TradfriAttributeType.HexString)]
        public int? ColorHex { get; set; }

        [TradfriAttribute(TradfriAttribute.LightColorHue)]
        public int? ColorHue { get; set; }

        [TradfriAttribute(TradfriAttribute.LightColorSaturation)]
        public int? ColorSaturation { get; set; }

        [TradfriAttribute(TradfriAttribute.LightColorX)]
        public int? ColorX { get; set; }

        [TradfriAttribute(TradfriAttribute.LightColorY)]
        public int? ColorY { get; set; }
    }
}
