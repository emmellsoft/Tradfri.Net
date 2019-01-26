using Tradfri.Net.Communication;
using Tradfri.Net.Communication.Objects;

namespace Tradfri.Net
{
    internal class RemoteDevice : Device, IRemoteDevice
    {
        public RemoteDevice(IGateway gateway, Request deviceRequest, DeviceResponse deviceResponse)
            : base(gateway, deviceRequest, deviceResponse, DeviceType.Remote)
        {
        }
    }
}
