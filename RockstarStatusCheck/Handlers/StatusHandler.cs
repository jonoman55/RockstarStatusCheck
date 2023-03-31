using RockstarStatusCheck.Classes;
using RockstarStatusCheck.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace RockstarStatusCheck.Handlers
{
    public class StatusHandler
    {
        #region Unused Code
        public static IEnumerable<ServicesPayload> ServicesStatuses =>
            new List<ServicesPayload>("services".RockstarJsonToJToken().Select(token => new ServicesPayload()
            {
                Id = token.JTokenToInt("id"),
                Name = token.JTokenToString("name"),
                Message = token.JTokenToString("message").StripHTML(),
                Updated = token.JTokenToString("updated"),
                Status = token.JTokenToStatus("status_tag"),
            }));

        public static IEnumerable<ServicesPayload> StatusesStatuses =>
            new List<ServicesPayload>("statuses".RockstarJsonToJToken().Select(token => new ServicesPayload()
            {
                Id = token.JTokenToInt("id"),
                Name = token.JTokenToString("name"),
                Message = token.JTokenToString("message").StripHTML(),
                Updated = token.JTokenToString("updated"),
                Status = token.JTokenToStatus("status_tag"),
            }));
        #endregion

        public static IEnumerable<ServicesPayload> GetStatuses(string name) =>
            new List<ServicesPayload>(name.RockstarJsonToJToken().Select(token => new ServicesPayload()
            {
                Id = token.JTokenToInt("id"),
                Name = token.JTokenToString("name"),
                Message = token.JTokenToString("message").StripHTML(),
                Updated = token.JTokenToString("updated"),
                Status = token.JTokenToStatus("status_tag"),
            }));

        public static IEnumerable<StatusesPayload> PlatformStatuses =>
            new List<StatusesPayload>("statuses".RockstarJsonToJToken().Select(token => new StatusesPayload()
            {
                Id = token.JTokenToInt("id"),
                Name = token.JTokenToString("name"),
                Message = token.JTokenToString("message").StripHTML(),
                Updated = token.JTokenToString("updated"),
                Status = token.JTokenToStatus("status_tag"),
                Platforms = token["services_platforms"].Select(platform => new Platform()
                {
                    Id = platform.JTokenToInt("id"),
                    Name = platform.JTokenToString("name"),
                    Updated = platform.JTokenToString("updated"),
                    PlatformStatus = new PlatformStatus()
                    {
                        Id = platform.JTokenDoubleToString("service_status", "id").StringToInt(),
                        Status = platform.JTokenDoubleToString("service_status", "status").JTokenToPlatformStatus()
                    }
                })
            }));
    }
}