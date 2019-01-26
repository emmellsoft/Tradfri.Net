using Tradfri.Net.Communication.Serialization;

namespace Tradfri.Net.Communication.Objects
{
    internal class AuthResponse
    {
        [TradfriAttribute(TradfriAttribute.Psk)]
        public string Psk { get; set; }

        [TradfriAttribute(TradfriAttribute.FirmwareVersion)]
        public string FirmwareVersion { get; set; }
    }
}
