using Tradfri.Net.Communication.Serialization;

namespace Tradfri.Net.Communication.Objects
{
    internal class SwitchPlugStatusUpdate
    {
        [TradfriAttribute(TradfriAttribute.DeviceState)]
        public int State { get; set; }

        [TradfriAttribute(TradfriAttribute.LightDimmer)]
        public int? Dimmer { get; set; }
    }
}
