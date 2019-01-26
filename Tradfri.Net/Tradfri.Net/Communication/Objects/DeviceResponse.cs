using System;
using System.Collections.Generic;
using Tradfri.Net.Communication.Serialization;

namespace Tradfri.Net.Communication.Objects
{
    internal class DeviceResponse
    {
        [TradfriAttribute(TradfriAttribute.Id)]
        public int Id { get; set; }

        [TradfriAttribute(TradfriAttribute.RootSwitch)]
        public List<RootSwitch> RootSwitch { get; set; }

        [TradfriAttribute(TradfriAttribute.DeviceInfo)]
        public DeviceInfoResponse Info { get; set; }

        [TradfriAttribute(TradfriAttribute.ApplicationType)]
        public DeviceType ApplicationType { get; set; }

        [TradfriAttribute(TradfriAttribute.Name)]
        public string Name { get; set; }

        [TradfriAttribute(TradfriAttribute.CreatedAt, TradfriAttributeType.UnixEpochSeconds)]
        public DateTime CreatedAt { get; set; }

        [TradfriAttribute(TradfriAttribute.ReachableState)]
        public int ReachableState { get; set; }

        [TradfriAttribute(TradfriAttribute.LastSeen, TradfriAttributeType.UnixEpochSeconds)]
        public DateTime LastSeen { get; set; }

        [TradfriAttribute(TradfriAttribute.OtaUpdateState)]
        public int OtaUpdateState { get; set; }

        [TradfriAttribute(TradfriAttribute.LightControl)]
        public List<LightStatusResponse> LightStatus { get; set; }

        [TradfriAttribute(TradfriAttribute.SwitchPlug)]
        public List<SwitchPlugStatusResponse> SwitchPlugStatus { get; set; }
    }
}
