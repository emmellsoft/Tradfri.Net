namespace Tradfri.Net.Communication.Objects
{
    internal static class SwitchPlugStatusResponseExtension
    {
        public static PlugStatus ToPlugStatus(this SwitchPlugStatusResponse lsr, IPlugDevice plugDevice)
        {
            return new PlugStatus(
                plugDevice,
                lsr.State == 1,
                (byte)(lsr.Dimmer ?? 255));
        }
    }
}
