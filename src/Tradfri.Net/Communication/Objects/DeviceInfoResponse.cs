using Tradfri.Net.Communication.Serialization;

namespace Tradfri.Net.Communication.Objects
{
    internal class DeviceInfoResponse
    {
        [TradfriAttribute(TradfriAttribute.DeviceInfoManufacturer)]
        public string Manufacturer { get; set; }

        [TradfriAttribute(TradfriAttribute.DeviceInfoDeviceType)]
        public string DeviceType { get; set; }

        [TradfriAttribute(TradfriAttribute.DeviceInfoSerial)]
        public string Serial { get; set; }

        [TradfriAttribute(TradfriAttribute.DeviceInfoFirmwareVersion)]
        public string FirmwareVersion { get; set; }

        [TradfriAttribute(TradfriAttribute.DeviceInfoPowerSource)]
        public PowerSource PowerSource { get; set; }

        [TradfriAttribute(TradfriAttribute.DeviceInfoBattery)]
        public byte Battery { get; set; }
    }
}
