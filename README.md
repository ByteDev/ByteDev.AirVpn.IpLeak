[![Build status](https://ci.appveyor.com/api/projects/status/github/bytedev/ByteDev.AirVpn.IpLeak?branch=master&svg=true)](https://ci.appveyor.com/project/bytedev/ByteDev-AirVpn-IpLeak/branch/master)
[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.AirVpn.IpLeak.svg)](https://www.nuget.org/packages/ByteDev.AirVpn.IpLeak)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/ByteDev/ByteDev.AirVpn.IpLeak/blob/master/LICENSE)

# ByteDev.AirVpn.IpLeak

.NET Standard library to help communicate with the IP Leak API.

IP Leak is a API service provided by AirVPN that allows the retrieval of information about a particular IP address, domain name etc.

## Installation

ByteDev.AirVpn.IpLeak is hosted as a package on nuget.org.  To install from the Package Manager Console in Visual Studio run:

`Install-Package ByteDev.AirVpn.IpLeak`

Further details can be found on the [nuget page](https://www.nuget.org/packages/ByteDev.AirVpn.IpLeak/).

## Release Notes

Releases follow semantic versioning.

Full details of the release notes can be viewed on [GitHub](https://github.com/ByteDev/ByteDev.AirVpn.IpLeak/blob/master/docs/RELEASE-NOTES.md).

## Usage

The main class in the assembly is `IpLeakClient` and has three public methods which each act against the IP Leak API:

- `GetIpDataAsync`
- `GetDomainDataAsync`
- `GetDnsDataAsync`

```csharp
// Retrieve data about a given IP address

const string ipAddress = "8.8.8.8";

IIpLeakClient client = new IpLeakClient(new HttpClient());

IpAddressResponse response = await client.GetIpDataAsync(ipAddress);

// response.CountryCode == "US"
// response.CountryName == "United States"
// response.ContinentCode == "NA"
// response.ContinentName == "North America"
// response.Latitude == 37.751
// response.Longitude = -97.822
// response.TimeZone == "America/Chicago"
// ...
```

## Links

- [IP Leak Website](https://ipleak.net/)
- [API further info](https://airvpn.org/forums/topic/14737-api/)