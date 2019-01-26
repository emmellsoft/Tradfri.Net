using System;

namespace Tradfri.Net
{
    public class DeviceStatus
    {
        public DeviceStatus(
            DeviceInfo info,
            string name,
            DateTime createdAt,
            bool isReachable,
            DateTime lastSeen,
            int otaUpdateState)
        {
            Info = info;
            Name = name;
            CreatedAt = createdAt;
            IsReachable = isReachable;
            LastSeen = lastSeen;
            OtaUpdateState = otaUpdateState;
        }

        public DeviceInfo Info { get; }

        public string Name { get; }

        public DateTime CreatedAt { get; }

        public bool IsReachable { get; }

        public DateTime LastSeen { get; }

        public int OtaUpdateState { get; }
    }
}
