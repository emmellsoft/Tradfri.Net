namespace Tradfri.Net
{
    public class DeviceInfo
    {
        public DeviceInfo(
            string manufacturer,
            string deviceType,
            string serial,
            string firmwareVersion,
            PowerSource powerSource,
            byte battery)
        {
            Manufacturer = manufacturer;
            DeviceType = deviceType;
            Serial = serial;
            FirmwareVersion = firmwareVersion;
            PowerSource = powerSource;
            Battery = battery;
        }

        public string Manufacturer { get; }

        public string DeviceType { get; }

        public string Serial { get; }

        public string FirmwareVersion { get; }

        public PowerSource PowerSource { get; }

        public byte Battery { get; }
    }
}
