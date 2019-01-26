using Tradfri.Net.Communication.Serialization;

namespace Tradfri.Net.Communication.Objects
{
    internal class SwitchPlugStatusUpdate
    {
        [TradfriAttribute(TradfriAttribute.LightState)]
        public int State { get; set; }

        [TradfriAttribute(TradfriAttribute.LightDimmer)]
        public int? Dimmer { get; set; }
    }
}
