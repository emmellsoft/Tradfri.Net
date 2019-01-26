using Tradfri.Net.Communication.Serialization;

namespace Tradfri.Net.Communication.Objects
{
    internal class AuthRequest
    {
        [TradfriAttribute(TradfriAttribute.Identity)]
        public string Identity { get; set; }
    }
}
