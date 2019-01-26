using System.Threading.Tasks;

namespace Tradfri.Net
{
    public interface IDeviceGroup
    {
        IGateway Gateway { get; }

        int Id { get; }

        Task<DeviceGroupStatus> GetStatus();

        Task<IMood[]> GetMoods();
    }
}
