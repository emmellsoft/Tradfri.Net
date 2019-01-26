using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tradfri.Net.Communication;
using Tradfri.Net.Communication.Objects;

namespace Tradfri.Net
{
    internal class Mood : IMood
    {
        private readonly Request _moodRequest;
        private readonly Func<int, Task<IDevice>> _getDeviceFunc;

        public Mood(
            IDeviceGroup deviceGroup,
            Request moodRequest,
            int id,
            Func<int, Task<IDevice>> getDeviceFunc)
        {
            _moodRequest = moodRequest;
            _getDeviceFunc = getDeviceFunc;
            DeviceGroup = deviceGroup;
            Id = id;
        }

        public IDeviceGroup DeviceGroup { get; }

        public int Id { get; }

        public async Task<MoodStatus> GetStatus()
        {
            MoodStatusResponse r = await _moodRequest.AppendPath(Id).Get<MoodStatusResponse>();

            var lightStatuses = new List<LightStatus>();
            if (r.LightStatuses != null)
            {
                foreach (LightStatusResponse lightStatusResponse in r.LightStatuses)
                {
                    lightStatuses.Add(await GetLightStatus(lightStatusResponse));
                }
            }

            return new MoodStatus(
                r.Name,
                r.CreatedAt,
                lightStatuses.ToArray());
        }

        private async Task<LightStatus> GetLightStatus(LightStatusResponse lsr)
        {
            IDevice device = await _getDeviceFunc(lsr.Id);

            var lightDevice = device as ILightDevice;
            if (lightDevice == null)
            {
                throw new TradfriException($"Device is not a light! ID={lsr.Id}");
            }

            return lsr.ToLightStatus(lightDevice);
        }
    }
}
