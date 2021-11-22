using System.Net;
using System.IO;

namespace RockstarStatusCheck.Tools
{
    public class HttpHandler
    {
        public static string RockstarServices()
        {
            string url = @"https://support.rockstargames.com/services/status.json?tz=America/New_York";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using Stream stream = response.GetResponseStream();
            using StreamReader reader = new(stream);
            return reader.ReadToEnd();
        }
    }
}