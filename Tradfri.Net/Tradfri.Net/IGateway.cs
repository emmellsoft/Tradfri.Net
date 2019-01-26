using System;
using System.Threading.Tasks;

namespace Tradfri.Net
{
    public interface IGateway : IDisposable
    {
        Task<GatewayStatus> GetStatus();

        Task<IDevice[]> GetDevices();

        Task<IDeviceGroup[]> GetGroups();

        Task FactoryReset();

        Task Reboot();

        Task<string> GetRaw(params object[] pathValues);
    }
}
