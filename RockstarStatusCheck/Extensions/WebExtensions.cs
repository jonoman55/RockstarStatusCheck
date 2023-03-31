using System.Net;

namespace RockstarStatusCheck.Extensions
{
    public static class WebExtensions
    {
        private const string Message = "Error Reaching Rockstar Services";

        public static HttpWebResponse CheckResponse(this HttpWebResponse response) =>
            response.StatusCode != HttpStatusCode.OK
                ? throw new WebException(Message)
                : response;

        public static HttpWebResponse GetServiceResponse(this string uri) =>
            (HttpWebResponse)((HttpWebRequest)WebRequest.Create(uri)).GetResponse();
    }
}
