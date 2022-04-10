using RockstarStatusCheck.Classes;

namespace RockstarStatusCheck.Interfaces
{
    public interface IPlaformPayload
    {
        int Id { get; set; }
        string Name { get; set; }
        string Updated { get; set; }
        PlatformStatus PlatformStatus { get; set; }
        string ToString();
    }
}
