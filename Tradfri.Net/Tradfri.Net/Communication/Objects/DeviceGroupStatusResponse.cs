using System;
using Tradfri.Net.Communication.Serialization;

namespace Tradfri.Net.Communication.Objects
{
    internal class DeviceGroupStatusResponse
    {
        [TradfriAttribute(TradfriAttribute.Id)]
        public int Id { get; set; }

        [TradfriAttribute(TradfriAttribute.CreatedAt, TradfriAttributeType.UnixEpochSeconds)]
        public DateTime CreatedAt { get; set; }

        [TradfriAttribute(TradfriAttribute.Name)]
        public string Name { get; set; }

        [TradfriAttribute(TradfriAttribute.LightState)]
        public int LightState { get; set; }

        [TradfriAttribute(TradfriAttribute.LightDimmer)]
        public int LightDimmer { get; set; }

        [TradfriAttribute(TradfriAttribute.Mood)]
        public int ActiveMoodId { get; set; }

        [TradfriAttribute(TradfriAttribute.Devices)]
        public DeviceGroupDevicesResponse Devices { get; set; }
    }

    public class DeviceGroupDevicesResponse
    {
        [TradfriAttribute(TradfriAttribute.DeviceIds)]
        public DeviceGroupDeviceIdsResponse DeviceIds { get; set; }
    }

    public class DeviceGroupDeviceIdsResponse
    {
        [TradfriAttribute(TradfriAttribute.Id)]
        public int[] Ids { get; set; }
    }
}
