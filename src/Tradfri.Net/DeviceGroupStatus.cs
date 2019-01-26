using System;

namespace Tradfri.Net
{
    public class DeviceGroupStatus
    {
        public DeviceGroupStatus(
            string name,
            DateTime createdAt,
            int lightState,
            int lightDimmer,
            IMood activeMood,
            IDevice[] devices)
        {
            CreatedAt = createdAt;
            Name = name;
            LightState = lightState;
            LightDimmer = lightDimmer;
            ActiveMood = activeMood;
            Devices = devices;
        }

        public string Name { get; }

        public DateTime CreatedAt { get; }

        public int LightState { get; }

        public int LightDimmer { get; }

        public IMood ActiveMood { get; }

        public IDevice[] Devices { get; }
    }
}
