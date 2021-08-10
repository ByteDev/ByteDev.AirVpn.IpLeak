using System;
using System.Text.Json.Serialization;

namespace ByteDev.AirVpn.IpLeak.Contract.Response
{
    /// <summary>
    /// Represents a base response from the IP Leak API.
    /// </summary>
    public abstract class IpLeakApiResponse
    {
        /// <summary>
        /// Indicates if the request was successful. If false then property ErrorMessage
        /// should be set.
        /// </summary>
        [JsonIgnore] 
        public bool IsSuccessful => string.IsNullOrEmpty(ErrorMessage);

        /// <summary>
        /// Any error message.
        /// </summary>
        [JsonPropertyName("error")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Query text. For example the IP address.
        /// </summary>
        [JsonPropertyName("query_text")]
        public string QueryText { get; set; }

        [JsonPropertyName("query_type")]
        public RequestQueryType RequestQueryType { get; set; }

        /// <summary>
        /// UTC server result date time.
        /// </summary>
        [JsonPropertyName("query_date")]
        public DateTime QueryDateTimeUtc { get; set; }
    }
}