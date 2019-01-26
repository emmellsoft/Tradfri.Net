using System;

namespace Tradfri.Net
{
    public class MoodStatus
    {
        public MoodStatus(
            string name,
            DateTime createdAt,
            LightStatus[] lightStatuses)
        {
            Name = name;
            CreatedAt = createdAt;
            LightStatuses = lightStatuses;
        }

        public string Name { get; }

        public DateTime CreatedAt { get; }

        public LightStatus[] LightStatuses { get; }
    }
}
