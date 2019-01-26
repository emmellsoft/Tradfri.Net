using System.Threading.Tasks;

namespace Tradfri.Net
{
    public interface IMood
    {
        IDeviceGroup DeviceGroup { get; }

        int Id { get; }

        Task<MoodStatus> GetStatus();
    }
}
