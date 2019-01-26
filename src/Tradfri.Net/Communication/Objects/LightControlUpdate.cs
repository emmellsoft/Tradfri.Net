using Tradfri.Net.Communication.Serialization;

namespace Tradfri.Net.Communication.Objects
{
    internal class LightControlUpdate
    {
        [TradfriAttribute(TradfriAttribute.LightControl)]
        public LightStatusUpdate[] LightControl { get; set; }
    }
}
