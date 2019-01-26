namespace Tradfri.Net
{
    public struct XyColor
    {
        public XyColor(ushort x, ushort y)
        {
            X = x;
            Y = y;
        }

        public ushort X { get; }

        public ushort Y { get; }

        public override string ToString() => $"X={X}, Y={Y}";
    }
}
