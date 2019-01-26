using Tradfri.Net.Communication.Serialization;

namespace Tradfri.Net.Communication.Objects
{
    internal class RootSwitch
    {
        [TradfriAttribute(TradfriAttribute.Id)]
        public int Id { get; set; }
    }
}
