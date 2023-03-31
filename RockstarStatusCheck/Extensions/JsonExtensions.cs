using Newtonsoft.Json.Linq;
using RockstarStatusCheck.Enums;
using RockstarStatusCheck.Handlers;
using System;

namespace RockstarStatusCheck.Extensions
{
    public static class JsonExtensions
    {
        public static string JTokenToString(this JToken token, string name) => 
            token[name].ToString();

        public static string JTokenDoubleToString(this JToken token, string prop1, string prop2) =>
            token[prop1][prop2].ToString();

        public static int JTokenToInt(this JToken token, string name) => 
            Convert.ToInt32(token.JTokenToString(name));

        public static int StringToInt(this string value) =>
            Convert.ToInt32(value);

        public static Status JTokenToStatus(this JToken token, string name) => 
            token.JTokenToString(name) switch
            {
                "Up" => Status.Up,
                "Down" => Status.Down,
                "Limited" => Status.Limited,
                _ => Status.NA,
            };

        public static Status JTokenToPlatformStatus(this string value) =>
            value switch
            {
                "UP" => Status.Up,
                "DOWN" => Status.Down,
                "LIMITED" => Status.Limited,
                _ => Status.NA,
            };

        public static JToken RockstarJsonToJToken(this string prop)
        {
            if (string.IsNullOrEmpty(prop))
            {
                throw new ArgumentException($"'{nameof(prop)}' cannot be null or empty.", nameof(prop));
            }
            string json = HttpHandler.GetRockstarServicesJson();
            return JObject.Parse(json)[prop];
        }

        public static JToken StringToJToken(this string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentException($"'{nameof(json)}' cannot be null or empty.", nameof(json));
            }
            return JObject.Parse(json);
        }
    } 
}
