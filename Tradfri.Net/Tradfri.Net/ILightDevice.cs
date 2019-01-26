using System.Threading.Tasks;

namespace Tradfri.Net
{
    public interface ILightDevice : IDevice
    {
        ColorSpectrum Spectrum { get; }

        bool CanSetBrightness { get; }

        bool CanSetTemperature { get; }

        bool CanSetColor { get; }

        LightStatus LastLightStatus { get; }

        Task<LightStatus> GetLightStatus();

        Task<bool> SetState(bool turnedOn);

        Task<bool> SetState(byte brightness);

        Task<bool> SetState(byte brightness, ColorTemperature temperature);

        Task<bool> SetState(byte brightness, RgbColor color);

        Task<bool> SetState(byte brightness, XyColor color);

        Task<bool> SetState(byte brightness, HsColor color);
    }
}
