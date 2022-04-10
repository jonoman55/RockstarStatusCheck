using RockstarStatusCheck.Enums;
using RockstarStatusCheck.Interfaces;
using System.Collections.Generic;

namespace RockstarStatusCheck.Classes
{
    public class StatusesPayload : IPayload, IStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string Updated { get; set; }
        public Status Status { get; set; }
        public IEnumerable<Platform> Platforms { get; set; }

        public override string ToString() => $"{Name} is {Status}";
    }

    public class Platform : IPlaformPayload
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Updated { get; set; }
        public PlatformStatus PlatformStatus { get; set; }

        public override string ToString() => $"{Name} is {PlatformStatus.Status}";
    }

    public class PlatformStatus : IStatus
    {
        public int Id { get; set; }
        public Status Status { get; set; }
    }
}
