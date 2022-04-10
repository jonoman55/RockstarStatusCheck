using RockstarStatusCheck.Enums;

namespace RockstarStatusCheck.Interfaces
{
    public interface IPayload
    {
        int Id { get; set; }
        string Name { get; set; }
        string Message { get; set; }
        string Updated { get; set; }
        Status Status { get; set; }
        string ToString();
    }
}
