using Tradfri.Net.Communication.Serialization;

namespace Tradfri.Net.Communication.Objects
{
    internal class SwitchPlugUpdate
    {
        [TradfriAttribute(TradfriAttribute.SwitchPlug)]
        public SwitchPlugStatusUpdate[] SwitchPlugStatus { get; set; }
    }
}
