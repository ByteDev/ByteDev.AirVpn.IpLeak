using System.Threading;
using System.Threading.Tasks;
using ByteDev.AirVpn.IpLeak.Contract.Response;

namespace ByteDev.AirVpn.IpLeak
{
    public interface IIpLeakClient
    {
        /// <summary>
        /// Retrieves data about a IP address.
        /// </summary>
        /// <param name="ipAddress">IP address to retrieve data about.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="ipAddress" /> is null or empty.</exception>
        /// <exception cref="T:ByteDev.AirVpn.IpLeak.IpLeakClientException">Error occurred while retrieving data for IP address.</exception>
        Task<IpAddressResponse> GetIpDataAsync(string ipAddress, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves data about a domain name.
        /// </summary>
        /// <param name="domainName">Domain name to retrieve data about.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="domainName" /> is null or empty.</exception>
        /// <exception cref="T:ByteDev.AirVpn.IpLeak.IpLeakClientException">Error occurred while retrieving data for domain name.</exception>
        Task<GetDomainDataResponse> GetDomainDataAsync(string domainName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves data about your DNS.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="T:ByteDev.AirVpn.IpLeak.IpLeakClientException">Error occurred while retrieving DNS data.</exception>
        Task<IpAddressResponse> GetDnsDataAsync(CancellationToken cancellationToken = default);
    }
}