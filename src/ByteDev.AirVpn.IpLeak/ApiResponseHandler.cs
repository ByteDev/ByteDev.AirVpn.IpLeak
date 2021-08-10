using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ByteDev.AirVpn.IpLeak.Contract.Response;
using ByteDev.AirVpn.IpLeak.Http;

namespace ByteDev.AirVpn.IpLeak
{
    internal static class ApiResponseHandler
    {
        public static async Task<T> HandleAsync<T>(HttpResponseMessage response) where T : class
        {
            var json = await response.Content.ReadAsStringAsync();

            response.ThrowIfNotSuccessful(json);

            return ApiSerializer.Deserialize<T>(json);
        }        
        
        public static async Task<GetDomainDataResponse> HandleGetDomainDataAsync(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();

            response.ThrowIfNotSuccessful(json);

            var obj = ApiSerializer.Deserialize<GetDomainDataResponse>(json);

            if (obj.IpEntries.Count == 0)
            {
                AddIpEntriesUsingJsonDom(obj, json);
            }

            return obj;
        }

        private static void AddIpEntriesUsingJsonDom(GetDomainDataResponse obj, string json)
        {
            using (var jsonDoc = JsonDocument.Parse(json))
            {
                JsonElement ips = jsonDoc.RootElement.GetProperty("ips");

                foreach (JsonProperty property in ips.EnumerateObject())
                {
                    var propertyJson = property.Value.GetRawText();

                    var ipAddressResponse = ApiSerializer.Deserialize<IpAddressResponse>(propertyJson);

                    obj.IpEntries.Add(ipAddressResponse);
                }
            }
        }
    }
}