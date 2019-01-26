namespace Tradfri.Net.Communication.Objects
{
    internal static class LightStatusResponseExtension
    {
        public static LightStatus ToLightStatus(this LightStatusResponse lsr, ILightDevice lightDevice)
        {
            return new LightStatus(
                lightDevice,
                lsr.State == 1,
                lsr.ToLightColor());
        }

        private static LightColor ToLightColor(this LightStatusResponse lsr)
        {
            byte brightness = (byte)(lsr.Dimmer ?? 255);

            ColorTemperature? temperature = lsr.Mireds == null
                ? (ColorTemperature?)null
                : ColorTemperature.FromMireds((ushort)lsr.Mireds.Value);

            RgbColor? rgbColor = lsr.ColorHex == null
                ? (RgbColor?)null
                : RgbColor.FromHex((int)lsr.ColorHex);

            XyColor? xyColor = (lsr.ColorX == null) || (lsr.ColorY == null)
                ? (XyColor?)null
                : new XyColor((ushort)lsr.ColorX, (ushort)lsr.ColorY);

            HsColor? hsColor = (lsr.ColorHue == null) || (lsr.ColorSaturation == null)
                ? (HsColor?)null
                : new HsColor((ushort)lsr.ColorHue, (ushort)lsr.ColorSaturation);

            return new LightColor(
                brightness,
                temperature,
                rgbColor,
                xyColor,
                hsColor);
        }
    }
}
