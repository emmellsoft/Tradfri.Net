using Tradfri.Net.Communication.Serialization;

namespace Tradfri.Net.Communication.Objects
{
    internal class SwitchPlugStatusResponse
    {
        [TradfriAttribute(TradfriAttribute.Id)]
        public int Id { get; set; }

        [TradfriAttribute(TradfriAttribute.LightState)]
        public int State { get; set; }

        [TradfriAttribute(TradfriAttribute.LightDimmer)]
        public int? Dimmer { get; set; }
    }
}
