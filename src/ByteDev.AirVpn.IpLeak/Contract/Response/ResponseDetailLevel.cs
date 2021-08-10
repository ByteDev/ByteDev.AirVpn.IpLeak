using ByteDev.Json.SystemTextJson.Serialization;

namespace ByteDev.AirVpn.IpLeak.Contract.Response
{
    /// <summary>
    /// Represents the level of detail returned from the IP Leak API
    /// in the response.
    /// </summary>
    public enum ResponseDetailLevel
    {
        Unknown = 0,

        [JsonEnumStringValue("min")]
        Min = 1,

        [JsonEnumStringValue("max")]
        Max = 2
    }
}