using RockstarStatusCheck.Enums;
using RockstarStatusCheck.Interfaces;

namespace RockstarStatusCheck.Classes
{
    public class ServicesPayload : IPayload, IStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string Updated { get; set; }
        public Status Status { get; set; }

        public override string ToString()
        {
            return $"{Name} is {Status}";
        }
    }
}