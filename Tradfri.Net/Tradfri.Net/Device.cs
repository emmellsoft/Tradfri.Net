using System.Threading.Tasks;
using Tradfri.Net.Communication;
using Tradfri.Net.Communication.Objects;
using Tradfri.Net.Communication.Serialization;

namespace Tradfri.Net
{
    internal class Device : IDevice
    {
        protected readonly Request DeviceRequest;

        public Device(
            IGateway gateway,
            Request deviceRequest,
            DeviceResponse deviceResponse,
            DeviceType deviceType)
        {
            Gateway = gateway;
            DeviceRequest = deviceRequest;
            LastStatus = ParseDeviceResponse(deviceResponse);
            DeviceType = deviceType;
            Id = deviceResponse.Id;
        }

        public IGateway Gateway { get; }

        public int Id { get; }

        public DeviceType DeviceType { get; }

        public DeviceStatus LastStatus { get; private set; }

        public async Task<DeviceStatus> GetStatus()
        {
            return ParseDeviceResponse(await DeviceRequest.Get<DeviceResponse>());
        }

        private DeviceStatus ParseDeviceResponse(DeviceResponse r)
        {
            DeviceInfo deviceInfo = new DeviceInfo(
                r.Info.Manufacturer,
                r.Info.DeviceType,
                r.Info.Serial,
                r.Info.FirmwareVersion,
                ConvertEnums.FromObject(r.Info.PowerSource),
                r.Info.Battery);

            return LastStatus = new DeviceStatus(
                deviceInfo,
                r.Name,
                r.CreatedAt,
                r.ReachableState == 1,
                r.LastSeen,
                r.OtaUpdateState);
        }
    }
}
