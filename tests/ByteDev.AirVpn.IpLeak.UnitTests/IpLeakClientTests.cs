using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ByteDev.AirVpn.IpLeak.Contract.Response;
using NUnit.Framework;

namespace ByteDev.AirVpn.IpLeak.UnitTests
{
    [TestFixture]
    public class IpLeakClientTests
    {
        private static IpLeakClient CreateSut(HttpStatusCode statusCode, string json)
        {
            return new IpLeakClient(new HttpClient(new FakeResponseHandler(statusCode, new StringContent(json))));
        }

        [TestFixture]
        public class GetIpDataAsync : IpLeakClientTests
        {
            [Test]
            public async Task WhenCalled_ThenReturnResponse()
            {
                const string json = @"{
                    ""country_code"": ""US"",
                    ""country_name"": ""United States"",
                    ""region_code"": null,
                    ""region_name"": null,
                    ""continent_code"": ""NA"",
                    ""continent_name"": ""North America"",
                    ""city_name"": null,
                    ""postal_code"": null,
                    ""postal_confidence"": null,
                    ""latitude"": 40.123,
                    ""longitude"": -90.123,
                    ""accuracy_radius"": 1000,
                    ""time_zone"": ""America\/Chicago"",
                    ""metro_code"": null,
                    ""level"": ""min"",
                    ""cache"": 1627555988,
                    ""ip"": ""8.8.8.8"",
                    ""reverse"": """",
                    ""query_text"": ""8.8.8.8"",
                    ""query_type"": ""ip"",
                    ""query_date"": 1627555988
                }";

                var sut = CreateSut(HttpStatusCode.OK, json);

                var result = await sut.GetIpDataAsync("8.8.8.8");

                Assert.That(result.CountryCode, Is.EqualTo("US"));
                Assert.That(result.CountryName, Is.EqualTo("United States"));
                Assert.That(result.RegionCode, Is.Null);
                Assert.That(result.RegionName, Is.Null);
                Assert.That(result.ContinentCode, Is.EqualTo("NA"));
                Assert.That(result.ContinentName, Is.EqualTo("North America"));
                Assert.That(result.CityName, Is.Null);
                Assert.That(result.PostalCode, Is.Null);
                Assert.That(result.PostalConfidence, Is.Null);
                Assert.That(result.Latitude, Is.EqualTo(40.123));
                Assert.That(result.Longitude, Is.EqualTo(-90.123));
                Assert.That(result.AccuracyRadius, Is.EqualTo(1000));
                Assert.That(result.TimeZone, Is.EqualTo("America/Chicago"));
                Assert.That(result.MetroCode, Is.Null);
                Assert.That(result.DetailLevel, Is.EqualTo(ResponseDetailLevel.Min));
                Assert.That(result.CacheDateTimeUtc, Is.EqualTo(new DateTime(2021, 7, 29, 10, 53, 8)));
                Assert.That(result.IpAddress, Is.EqualTo("8.8.8.8"));
                Assert.That(result.Reverse, Is.Empty);
                Assert.That(result.QueryText, Is.EqualTo("8.8.8.8"));
                Assert.That(result.RequestQueryType, Is.EqualTo(RequestQueryType.TargetIpAddress));
                Assert.That(result.QueryDateTimeUtc, Is.EqualTo(new DateTime(2021, 7, 29, 10, 53, 8)));
            }

            [TestCase(@"{ ""query_type"": null }", RequestQueryType.Unknown)]
            [TestCase(@"{ ""query_type"": """" }", RequestQueryType.Unknown)]
            [TestCase(@"{ ""query_type"": ""notvalid"" }", RequestQueryType.Unknown)]
            [TestCase(@"{ ""query_type"": ""myip"" }", RequestQueryType.MyIpAddress)]
            [TestCase(@"{ ""query_type"": ""mydns"" }", RequestQueryType.MyDns)]
            [TestCase(@"{ ""query_type"": ""ip"" }", RequestQueryType.TargetIpAddress)]
            [TestCase(@"{ ""query_type"": ""domain"" }", RequestQueryType.TargetDomainName)]
            public async Task WhenJsonQueryTypeProvided_ThenSetQueryType(string json, RequestQueryType expected)
            {
                var sut = CreateSut(HttpStatusCode.OK, json);

                var result = await sut.GetIpDataAsync("8.8.8.8");

                Assert.That(result.RequestQueryType, Is.EqualTo(expected));
            }

            [TestCase(@"{ ""level"": null }", ResponseDetailLevel.Unknown)]
            [TestCase(@"{ ""level"": """" }", ResponseDetailLevel.Unknown)]
            [TestCase(@"{ ""level"": ""notvalid"" }", ResponseDetailLevel.Unknown)]
            [TestCase(@"{ ""level"": ""min"" }", ResponseDetailLevel.Min)]
            [TestCase(@"{ ""level"": ""max"" }", ResponseDetailLevel.Max)]
            public async Task WhenJsonLevelProvided_ThenSetDetailLevel(string json, ResponseDetailLevel expected)
            {
                var sut = CreateSut(HttpStatusCode.OK, json);

                var result = await sut.GetIpDataAsync("8.8.8.8");

                Assert.That(result.DetailLevel, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class GetDomainDataAsync : IpLeakClientTests
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenDomainIsNullOrEmpty_ThenThrowException(string domainName)
            {
                var sut = CreateSut(HttpStatusCode.OK, "{}");

                Assert.ThrowsAsync<ArgumentException>(() => _ = sut.GetDomainDataAsync(domainName));
            }
        }
    }
}
