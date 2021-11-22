using Newtonsoft.Json.Linq;
using RockstarStatusCheck.Classes;
using System;
using System.Collections.Generic;

namespace RockstarStatusCheck.Tools
{
    public class StatusHandler
    {
        // TODO : Add statuses JSON and include platform_status info
        // TODO : Add logic to check if the PC platform is down
        public static IEnumerable<ServiceStatus> GetServiceStatuses()
        {
            List<ServiceStatus> serviceStatuses = new();
            var response = HttpHandler.RockstarServices();
            var jArray = JObject.Parse(response);
            var results = jArray["services"];
            foreach (var token in results)
            {
                serviceStatuses.Add(new()
                {
                    Id = Convert.ToInt32(token["id"].ToString()),
                    Name = token["name"].ToString(),
                    Message = token["message"].ToString(),
                    Updated = token["updated"].ToString(),
                    Status = GetStatus(token["status_tag"].ToString()),
                });
            }
            return serviceStatuses;
        }

        public static Status GetStatus(string status)
        {
            Status result = Status.Up;
            switch (status)
            {
                case "Up":
                    result = Status.Up;
                    break;
                case "Down":
                    result = Status.Down;
                    break;
                case "Limited":
                    result = Status.Limited;
                    break;
            }
            return result;
        }
    }
}