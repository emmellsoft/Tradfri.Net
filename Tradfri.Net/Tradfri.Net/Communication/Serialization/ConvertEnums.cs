namespace Tradfri.Net.Communication.Serialization
{
    internal static class ConvertEnums
    {
        public static PowerSource FromObject(Objects.PowerSource value)
        {
            switch (value)
            {
                case Objects.PowerSource.InternalBattery: return PowerSource.InternalBattery;
                case Objects.PowerSource.ExternalBattery: return PowerSource.ExternalBattery;
                case Objects.PowerSource.Battery: return PowerSource.Battery;
                case Objects.PowerSource.PowerOverEthernet: return PowerSource.PowerOverEthernet;
                case Objects.PowerSource.Usb: return PowerSource.Usb;
                case Objects.PowerSource.Mains: return PowerSource.Mains;
                case Objects.PowerSource.Solar: return PowerSource.Solar;
                default:
                    return PowerSource.Unknown;
            }
        }
    }
}
