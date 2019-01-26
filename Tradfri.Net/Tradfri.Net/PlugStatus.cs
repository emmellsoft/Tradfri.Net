namespace Tradfri.Net
{
    public class PlugStatus
    {
        public PlugStatus(IPlugDevice plugDevice, bool isOn, byte dimmer)
        {
            PlugDevice = plugDevice;
            IsOn = isOn;
            Dimmer = dimmer;
        }

        public IPlugDevice PlugDevice { get; }

        public bool IsOn { get; }

        public byte Dimmer { get; }
    }
}
