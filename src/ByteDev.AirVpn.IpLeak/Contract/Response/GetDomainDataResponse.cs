using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ByteDev.AirVpn.IpLeak.Contract.Response
{
    /// <summary>
    /// Represents a response to get data about a particular domain name.
    /// </summary>
    public class GetDomainDataResponse : IpLeakApiResponse
    {
        private IList<IpAddressResponse> _ipEntries;

        /// <summary>
        /// Information about all the associated IP addresses to the domain name.
        /// </summary>
        [JsonIgnore]
        public IList<IpAddressResponse> IpEntries
        {
            get => _ipEntries ?? (_ipEntries = new List<IpAddressResponse>());
            set => _ipEntries = value;
        }
    }
}