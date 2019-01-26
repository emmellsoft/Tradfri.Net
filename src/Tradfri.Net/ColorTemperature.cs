namespace Tradfri.Net
{
    public struct ColorTemperature
    {
        public static ColorTemperature FromMireds(ushort mireds)
        {
            return new ColorTemperature(mireds, true);
        }

        public static ColorTemperature FromKelvin(ushort kelvin)
        {
            return new ColorTemperature(kelvin, false);
        }

        private ColorTemperature(ushort value, bool isMireds)
        {
            if (isMireds)
            {
                Mireds = value;
                Kelvin = value == 0 ? (ushort)0 : (ushort)(1000000.0 / value);
            }
            else
            {
                Kelvin = value;
                Mireds = value == 0 ? (ushort)0 : (ushort)(1000000.0 / value);
            }
        }

        public ushort Mireds { get; }

        public ushort Kelvin { get; }

        public override string ToString() => $"{Mireds} mired, {Kelvin} K";
    }
}
