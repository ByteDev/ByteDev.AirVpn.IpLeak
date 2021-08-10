using System.Net.Http;

namespace ByteDev.AirVpn.IpLeak.Http
{
    internal static class HttpResponseMessageExtensions
    {
        public static void ThrowIfNotSuccessful(this HttpResponseMessage response, string json)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new IpLeakClientException($"IP Leak API request was not successful. Response status code: '{response.StatusCode}'. Response content: '{json}'.");
            }
        }
    }
}