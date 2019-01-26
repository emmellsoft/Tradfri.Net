using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Tradfri.Net.Communication;
using Tradfri.Net.Communication.Objects;

namespace Tradfri.Net
{
    internal class DeviceGroup : IDeviceGroup
    {
        private readonly Request _groupRequest;
        private readonly Request _moodRequest;
        private readonly Func<int[], Task<IDevice[]>> _getDevicesFunc;
        private readonly ConcurrentDictionary<int, IMood> _moods = new ConcurrentDictionary<int, IMood>();

        public DeviceGroup(
            IGateway gateway,
            Request groupRequest,
            Request moodRequest,
            int id,
            Func<int[], Task<IDevice[]>> getDevicesFunc)
        {
            _groupRequest = groupRequest;
            _moodRequest = moodRequest;
            _getDevicesFunc = getDevicesFunc;
            Gateway = gateway;
            Id = id;
        }

        public IGateway Gateway { get; }

        public int Id { get; }

        public async Task<DeviceGroupStatus> GetStatus()
        {
            DeviceGroupStatusResponse r = await _groupRequest.Get<DeviceGroupStatusResponse>();

            return new DeviceGroupStatus(
                r.Name,
                r.CreatedAt,
                r.State,
                r.LightDimmer,
                GetMood(r.ActiveMoodId),
                await _getDevicesFunc(r.Devices.DeviceIds.Ids));
        }

        public async Task<IMood[]> GetMoods()
        {
            int[] moodIds = await _moodRequest.Get<int[]>();

            return moodIds.Select(GetMood).ToArray();
        }

        private IMood GetMood(int moodId)
        {
            return _moods.GetOrAdd(moodId, id => new Mood(this, _moodRequest, id, GetDeviceFunc));
        }

        private async Task<IDevice> GetDeviceFunc(int id)
        {
            IDevice[] devices = await _getDevicesFunc(new[] { id });
            return devices[0];
        }
    }
}
