using System.Net;

namespace RockstarStatusCheck.Extensions
{
    public static class WebExtensions
    {
        public static HttpWebResponse CheckResponse(this HttpWebResponse response) => 
            response.StatusCode != HttpStatusCode.OK 
                ? throw new WebException("Error reaching Rockstar Services") 
                : response;

        public static HttpWebResponse GetServiceResponse(this string uri) =>
            (WebRequest.Create(uri) as HttpWebRequest).GetResponse() as HttpWebResponse;
    }
}
