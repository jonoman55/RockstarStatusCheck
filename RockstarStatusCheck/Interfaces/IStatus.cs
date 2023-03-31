using RockstarStatusCheck.Enums;

namespace RockstarStatusCheck.Interfaces
{
    interface IStatus
    {
        Status Status { get; set; }

        string ToString();
    }
}
