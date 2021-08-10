using System;
using System.Text.Json.Serialization;

namespace ByteDev.AirVpn.IpLeak.Contract.Response
{
    public class IpAddressResponse : IpLeakApiResponse
    {
        /// <summary>
        /// Level of detail in the response. Only some IP addresses are fetched for all
        /// available data (max levels).
        /// </summary>
        [JsonPropertyName("level")]
        public ResponseDetailLevel DetailLevel { get; set; }

        /// <summary>
        /// UTC date time of data accuracy if the detail level if max. Data at min level
        /// are always in real time.
        /// </summary>
        [JsonPropertyName("cache")]
        public DateTime CacheDateTimeUtc { get; set; }

        /// <summary>
        /// Country ISO code.
        /// </summary>
        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Country name.
        /// </summary>
        [JsonPropertyName("country_name")]
        public string CountryName { get; set; }

        /// <summary>
        /// Region code.
        /// </summary>
        [JsonPropertyName("region_code")]
        public string RegionCode { get; set; }

        /// <summary>
        /// Region name.
        /// </summary>
        [JsonPropertyName("region_name")]
        public string RegionName { get; set; }

        /// <summary>
        /// Contient code.
        /// </summary>
        [JsonPropertyName("continent_code")]
        public string ContinentCode { get; set; }

        /// <summary>
        /// Contient name.
        /// </summary>
        [JsonPropertyName("continent_name")]
        public string ContinentName { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        [JsonPropertyName("city_name")]
        public string CityName { get; set; }

        /// <summary>
        /// Postal code.
        /// </summary>
        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }

        [JsonPropertyName("postal_confidence")]
        public string PostalConfidence { get; set; }

        /// <summary>
        /// Latitudinal (north/south) position.
        /// </summary>
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitudinal (east/west) postion.
        /// </summary>
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        /// <summary>
        /// Latitude and longitude accuracy radius in kilometers.
        /// </summary>
        [JsonPropertyName("accuracy_radius")]
        public int AccuracyRadius { get; set; }

        /// <summary>
        /// Time zone.
        /// </summary>
        [JsonPropertyName("time_zone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("metro_code")]
        public int MetroCode { get; set; }
        
        /// <summary>
        /// IP address.
        /// </summary>
        [JsonPropertyName("ip")]
        public string IpAddress { get; set; }

        /// <summary>
        /// Reverse lookup.
        /// </summary>
        [JsonPropertyName("reverse")]
        public string Reverse { get; set; }
        
        [JsonPropertyName("block")]
        public string Block { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("rfc")]
        public string Rfc { get; set; }

        [JsonPropertyName("allocation-date")]
        public string AllocationDate { get; set; }

        [JsonPropertyName("termination-date")]
        public string TerminationDate { get; set; }

        [JsonPropertyName("source")]
        public bool Source { get; set; }

        [JsonPropertyName("destination")]
        public bool Destination { get; set; }

        [JsonPropertyName("forwardable")]
        public bool Forwardable { get; set; }

        [JsonPropertyName("global")]
        public bool Global { get; set; }

        [JsonPropertyName("reserved-by-protocol")]
        public bool ReservedByProtocol { get; set; }

        [JsonPropertyName("space")]
        public int Space { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}