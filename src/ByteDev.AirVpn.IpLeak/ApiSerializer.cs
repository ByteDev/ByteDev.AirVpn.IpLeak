using System.Text.Json;
using ByteDev.AirVpn.IpLeak.Contract.Response;
using ByteDev.Json.SystemTextJson.Serialization;

namespace ByteDev.AirVpn.IpLeak
{
    internal static class ApiSerializer
    {
        public static T Deserialize<T>(string json) where T : class
        {
            var options = new JsonSerializerOptions();

            options.Converters.Add(new UnixEpochTimeToDateTimeJsonConverter());
            options.Converters.Add(new EnumJsonConverter<RequestQueryType>(RequestQueryType.Unknown));
            options.Converters.Add(new EnumJsonConverter<ResponseDetailLevel>(ResponseDetailLevel.Unknown));

            return JsonSerializer.Deserialize<T>(json, options);
        }
    }
}