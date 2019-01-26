using System.Threading.Tasks;

namespace Tradfri.Net
{
    public interface IPlugDevice : IDevice
    {
        PlugStatus LastPlugStatus { get; }

        Task<PlugStatus> GetPlugStatus();

        Task<bool> SetState(bool turnedOn);

        Task<bool> SetState(byte dimmer);
    }
}
