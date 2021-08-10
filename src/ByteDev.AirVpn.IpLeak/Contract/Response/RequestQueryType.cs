using ByteDev.Json.SystemTextJson.Serialization;

namespace ByteDev.AirVpn.IpLeak.Contract.Response
{
    /// <summary>
    /// Represents the type of request query.
    /// </summary>
    public enum RequestQueryType
    {
        Unknown = 0,

        /// <summary>
        /// Query was made using the local machine's IP address.
        /// </summary>
        [JsonEnumStringValue("myip")]
        MyIpAddress = 1,

        /// <summary>
        /// Query was made using the local machine's DNS.
        /// </summary>
        [JsonEnumStringValue("mydns")]
        MyDns = 2,

        /// <summary>
        /// Query was made with a provided target IP address.
        /// </summary>
        [JsonEnumStringValue("ip")]
        TargetIpAddress = 3,

        /// <summary>
        /// Query was made with a provided domain name.
        /// </summary>
        [JsonEnumStringValue("domain")]
        TargetDomainName = 4
    }
}