namespace Tradfri.Net
{
    public struct RgbColor
    {
        public static RgbColor FromHex(int value)
        {
            return new RgbColor(value);
        }

        public static RgbColor FromRgb(byte red, byte green, byte blue)
        {
            return new RgbColor(red, green, blue);
        }

        public static RgbColor FromEnum(Color value)
        {
            return new RgbColor((int)value);
        }

        private RgbColor(int value)
        {
            Value = value & 0xFFFFFF;
            Red = (byte)((value >> 16) & 0xFF);
            Green = (byte)((value >> 8) & 0xFF);
            Blue = (byte)(value & 0xFF);
        }

        private RgbColor(byte red, byte green, byte blue)
        {
            Value = (red << 16) | (green << 8) | blue;
            Red = red;
            Green = green;
            Blue = blue;
        }

        public int Value { get; }

        public byte Red { get; }

        public byte Green { get; }

        public byte Blue { get; }

        public override string ToString() => $"R={Red}, G={Green}, B={Blue}";
    }
}
