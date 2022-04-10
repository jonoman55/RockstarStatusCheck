using RockstarStatusCheck.Extensions;
using System.IO;

namespace RockstarStatusCheck.Handlers
{
    public class HttpHandler
    {
        private const string ENDPOINT = @"https://support.rockstargames.com/services/status.json?tz=America/New_York";

        public static string GetRockstarServicesJson()
        {
            using var response = ENDPOINT.GetServiceResponse().CheckResponse();
            using var reader = new StreamReader(response.GetResponseStream());
            return reader.ReadToEnd();
        }
    }
}