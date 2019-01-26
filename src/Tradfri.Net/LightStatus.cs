namespace Tradfri.Net
{
    public class LightStatus
    {
        public LightStatus(ILightDevice lightDevice, bool isOn, LightColor color)
        {
            LightDevice = lightDevice;
            IsOn = isOn;
            Color = color;
        }

        public ILightDevice LightDevice { get; }

        public bool IsOn { get; }

        public LightColor Color { get; }
    }
}
