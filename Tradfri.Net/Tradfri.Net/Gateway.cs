using Com.AugustCellars.CoAP.Net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tradfri.Net.Communication;
using Tradfri.Net.Communication.Objects;

namespace Tradfri.Net
{
    internal class Gateway : IGateway
    {
        private readonly EndPointInfo _endPointInfo;
        private readonly ConcurrentDictionary<int, Task<IDevice>> _devices = new ConcurrentDictionary<int, Task<IDevice>>();
        private readonly ConcurrentDictionary<int, Task<IDeviceGroup>> _groups = new ConcurrentDictionary<int, Task<IDeviceGroup>>();

        public Gateway(IEndPoint endPoint, Uri uri, ILogger logger)
        {
            _endPointInfo = new EndPointInfo(endPoint, uri, logger);
        }

        public async Task<GatewayStatus> GetStatus()
        {
            GatewayResponse r = await _endPointInfo
                .GetRequest(RequestRoot.Gateway)
                .AppendPath(TradfriAttribute.GatewayInfo)
                .Get<GatewayResponse>();

            return new GatewayStatus(
                r.NetworkTimeProtocol,
                r.GatewayTimeSource,
                r.CurrentTime,
                r.CommissioningMode,
                r.Firmware,
                r.GatewayId,
                r.GoogleHomePairStatus,
                r.AlexaPairStatus,
                r.HomekitId,
                r.OtaUpdateState,
                r.GatewayUpdateProgress,
                r.OtaType,
                r.FirstSetup,
                r.CertificateProvider);
        }

        public async Task<IDevice[]> GetDevices()
        {
            int[] deviceIds = await _endPointInfo
                .GetRequest(RequestRoot.Devices)
                .Get<int[]>();

            return await GetDevices(deviceIds);
        }

        private async Task<IDevice[]> GetDevices(int[] deviceIds)
        {
            var devices = new List<IDevice>();

            foreach (int deviceId in deviceIds)
            {
                devices.Add(await GetDevice(deviceId));
            }

            return devices.OrderBy(x => x.DeviceType).ThenBy(x => x.LastStatus.Name).ToArray();
        }

        private Task<IDevice> GetDevice(int deviceId)
        {
            return _devices.GetOrAdd(deviceId, CreateDevice);
        }

        private async Task<IDevice> CreateDevice(int deviceId)
        {
            Request baseRequest = _endPointInfo
                .GetRequest(RequestRoot.Devices)
                .AppendPath(deviceId);

            DeviceResponse deviceResponse = await baseRequest.Get<DeviceResponse>();

            switch (deviceResponse.ApplicationType)
            {
                case Communication.Objects.DeviceType.Remote:
                case Communication.Objects.DeviceType.SlaveRemote:
                    return new RemoteDevice(this, baseRequest, deviceResponse);

                case Communication.Objects.DeviceType.Light:
                    return new LightDevice(this, baseRequest, deviceResponse);

                case Communication.Objects.DeviceType.Plug:
                    return new PlugDevice(this, baseRequest, deviceResponse);

                default:
                    DeviceType deviceType;
                    switch (deviceResponse.ApplicationType)
                    {
                        case Communication.Objects.DeviceType.MotionSensor:
                            deviceType = DeviceType.MotionSensor;
                            break;

                        default:
                            deviceType = DeviceType.Unknown;
                            break;
                    }

                    return new Device(this, baseRequest, deviceResponse, deviceType);
            }
        }

        public async Task<IDeviceGroup[]> GetGroups()
        {
            int[] groupIds = await _endPointInfo
                .GetRequest(RequestRoot.Groups)
                .Get<int[]>();

            var groups = new List<IDeviceGroup>();

            foreach (int groupId in groupIds)
            {
                groups.Add(await _groups.GetOrAdd(groupId, CreateGroup));
            }

            return groups.ToArray();
        }

        public async Task FactoryReset()
        {
            string r = await _endPointInfo
                .GetRequest(RequestRoot.Gateway)
                .AppendPath(TradfriAttribute.GatewayFactoryDefaults)
                .Post(null);
        }

        public async Task Reboot()
        {
            string r = await _endPointInfo
                .GetRequest(RequestRoot.Gateway)
                .AppendPath(TradfriAttribute.GatewayReboot)
                .Post(null);
        }

        public Task<string> GetRaw(params object[] pathValues)
        {
            Request request = _endPointInfo.GetRawRequest(pathValues.Select(x => x.ToString()));
            return request.Get();
        }

        private Task<IDeviceGroup> CreateGroup(int groupId)
        {
            Request groupRequest = _endPointInfo
                .GetRequest(RequestRoot.Groups)
                .AppendPath(groupId);

            Request moodRequest = _endPointInfo
                .GetRequest(RequestRoot.Moods)
                .AppendPath(groupId);

            var deviceGroup = new DeviceGroup(
                this,
                groupRequest,
                moodRequest,
                groupId,
                GetDevices);

            return Task.FromResult<IDeviceGroup>(deviceGroup);
        }

        public void Dispose()
        {
            _endPointInfo.Dispose();
        }
    }
}
