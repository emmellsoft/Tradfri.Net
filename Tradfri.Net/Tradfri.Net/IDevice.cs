using System.Threading.Tasks;

namespace Tradfri.Net
{
    public interface IDevice
    {
        IGateway Gateway { get; }

        int Id { get; }

        DeviceType DeviceType { get; }

        DeviceStatus LastStatus { get; }

        Task<DeviceStatus> GetStatus();
    }
}
