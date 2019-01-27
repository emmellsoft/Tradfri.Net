using System;
using System.Threading.Tasks;

namespace Tradfri.Net
{
    public interface IPlugDevice : IDevice
    {
        event Action<IPlugDevice, PlugStatus> PlugStatusChanged;

        PlugStatus LastPlugStatus { get; }

        Task<PlugStatus> GetPlugStatus();

        Task<bool> SetState(bool turnedOn);

        Task<bool> SetState(byte dimmer);
    }
}
