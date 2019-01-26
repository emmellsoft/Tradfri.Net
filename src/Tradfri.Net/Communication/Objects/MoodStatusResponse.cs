using System;
using Tradfri.Net.Communication.Serialization;

namespace Tradfri.Net.Communication.Objects
{
    internal class MoodStatusResponse
    {
        [TradfriAttribute(TradfriAttribute.Id)]
        public int Id { get; set; }

        [TradfriAttribute(TradfriAttribute.Name)]
        public string Name { get; set; }

        [TradfriAttribute(TradfriAttribute.CreatedAt, TradfriAttributeType.UnixEpochSeconds)]
        public DateTime CreatedAt { get; set; }

        [TradfriAttribute(TradfriAttribute.LightStatuses)]
        public LightStatusResponse[] LightStatuses { get; set; }

        [TradfriAttribute(9057)]
        public int The9057 { get; set; }

        [TradfriAttribute(9068)]
        public int The9068 { get; set; }
    }
}
