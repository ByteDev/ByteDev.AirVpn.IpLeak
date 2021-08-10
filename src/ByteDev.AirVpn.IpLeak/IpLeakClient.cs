using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ByteDev.AirVpn.IpLeak.Contract.Response;

namespace ByteDev.AirVpn.IpLeak
{
    /// <summary>
    /// Represents a client to help communicate with the IP Leak API.
    /// </summary>
    public class IpLeakClient : IIpLeakClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.AirVpn.IpLeak.IpLeakClient" /> class.
        /// </summary>
        /// <param name="httpClient">HttpClient instance to use when making API requests.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="httpClient" /> is null.</exception>
        public IpLeakClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Retrieves data about a IP address.
        /// </summary>
        /// <param name="ipAddress">IP address to retrieve data about.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="ipAddress" /> is null or empty.</exception>
        /// <exception cref="T:ByteDev.AirVpn.IpLeak.IpLeakClientException">Error occurred while retrieving data for IP address.</exception>
        public async Task<IpAddressResponse> GetIpDataAsync(string ipAddress, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(ipAddress))
                throw new ArgumentException("IP address was null or empty.", nameof(ipAddress));

            try
            {
                var uri = ApiUriFactory.CreateGetIpData(ipAddress);

                var response = await _httpClient.GetAsync(uri, cancellationToken);

                return await ApiResponseHandler.HandleAsync<IpAddressResponse>(response);
            }
            catch (Exception ex)
            {
                throw new IpLeakClientException("Error occurred while retrieving data for IP address.", ex);
            }
        }

        /// <summary>
        /// Retrieves data about a domain name.
        /// </summary>
        /// <param name="domainName">Domain name to retrieve data about.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="domainName" /> is null or empty.</exception>
        /// <exception cref="T:ByteDev.AirVpn.IpLeak.IpLeakClientException">Error occurred while retrieving data for domain name.</exception>
        public async Task<GetDomainDataResponse> GetDomainDataAsync(string domainName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(domainName))
                throw new ArgumentException("Domain name was null or empty.", nameof(domainName));

            try
            {
                var uri = ApiUriFactory.CreateGetDomainData(domainName);

                var response = await _httpClient.GetAsync(uri, cancellationToken);
                
                return await ApiResponseHandler.HandleGetDomainDataAsync(response);
            }
            catch (Exception ex)
            {
                throw new IpLeakClientException("Error occurred while retrieving data for domain name.", ex);
            }
        }

        /// <summary>
        /// Retrieves data about your DNS.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="T:ByteDev.AirVpn.IpLeak.IpLeakClientException">Error occurred while retrieving DNS data.</exception>
        public async Task<IpAddressResponse> GetDnsDataAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var uri = ApiUriFactory.CreateGetDnsData();

                var response = await _httpClient.GetAsync(uri, cancellationToken);

                return await ApiResponseHandler.HandleAsync<IpAddressResponse>(response);
            }
            catch (Exception ex)
            {
                throw new IpLeakClientException("Error occurred while retrieving DNS data.", ex);
            }
        }
    }
}