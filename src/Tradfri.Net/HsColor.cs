namespace Tradfri.Net
{
    public struct HsColor
    {
        public HsColor(ushort hue, ushort saturation)
        {
            Hue = hue;
            Saturation = saturation;
        }

        public ushort Hue { get; }

        public ushort Saturation { get; }

        public override string ToString() => $"Hue={Hue}, Saturation={Saturation}";
    }
}
