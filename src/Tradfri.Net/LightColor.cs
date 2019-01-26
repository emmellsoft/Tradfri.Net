using System.Text;

namespace Tradfri.Net
{
    public class LightColor
    {
        internal LightColor(
            byte brightness,
            ColorTemperature? temperature,
            RgbColor? rgbColor,
            XyColor? xyColor,
            HsColor? hsColor)
        {
            Brightness = brightness;
            Temperature = temperature;
            RgbColor = rgbColor;
            XyColor = xyColor;
            HsColor = hsColor;
        }

        public byte Brightness { get; }

        public ColorTemperature? Temperature { get; }

        public RgbColor? RgbColor { get; }

        public XyColor? XyColor { get; }

        public HsColor? HsColor { get; }

        public override string ToString()
        {
            var text = new StringBuilder();
            text.Append($"Brightness={Brightness}");

            if (Temperature != null)
            {
                text.Append($", {Temperature}");
            }

            if (RgbColor != null)
            {
                text.Append($", {RgbColor}");
            }

            if (XyColor != null)
            {
                text.Append($", {XyColor}");
            }

            if (HsColor != null)
            {
                text.Append($", {HsColor}");
            }

            return text.ToString();
        }
    }
}
