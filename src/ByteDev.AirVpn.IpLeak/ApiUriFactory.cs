using System;
using ByteDev.Crypto.Random;

namespace ByteDev.AirVpn.IpLeak
{
    internal static class ApiUriFactory
    {
        public static Uri CreateGetIpData(string ipAddress)
        {
            return new Uri("https://ipleak.net/json/" + ipAddress);
        }

        public static Uri CreateGetDomainData(string domainName)
        {
            return new Uri("https://ipleak.net/json/" + domainName);
        }

        public static Uri CreateGetDnsData()
        {
            using (var cr = new CryptoRandom("0123456789abcdef"))
            {
                var hash = cr.GenerateString(40);

                return new Uri("https://" + hash + ".ipleak.net/json/");
            }
        }
    }
}