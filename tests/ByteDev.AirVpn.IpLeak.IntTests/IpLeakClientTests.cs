using System.Net.Http;
using System.Threading.Tasks;
using ByteDev.AirVpn.IpLeak.Contract.Response;
using NUnit.Framework;

namespace ByteDev.AirVpn.IpLeak.IntTests
{
    [TestFixture]
    public class IpLeakClientTests
    {
        private IpLeakClient _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new IpLeakClient(new HttpClient());
        }

        [TestFixture]
        public class GetIpDataAsync : IpLeakClientTests
        {
            [Test]
            public async Task WhenIpProvidedIsNotValid_ThenReturnError()
            {
                var result = await _sut.GetIpDataAsync("notIpAddress");

                Assert.That(result.IsSuccessful, Is.False);
                Assert.That(result.ErrorMessage, Is.EqualTo("Unable to resolve."));
            }

            [Test]
            public async Task WhenIpProvided_ThenReturnsResponse()
            {
                const string ipAddress = "8.8.8.8";

                var result = await _sut.GetIpDataAsync(ipAddress);

                Assert.That(result.IsSuccessful, Is.True);
                Assert.That(result.QueryText, Is.EqualTo(ipAddress));
            }

            [Test]
            public async Task WhenIpProvidedIsReservedAddress_ThenReturnMaxResponse()
            {
                const string ipAddress = "127.0.0.1";

                var result = await _sut.GetIpDataAsync(ipAddress);

                Assert.That(result.IsSuccessful, Is.True);
                Assert.That(result.QueryText, Is.EqualTo(ipAddress));
                Assert.That(result.DetailLevel, Is.EqualTo(ResponseDetailLevel.Max));
            }
        }

        [TestFixture]
        public class GetDomainDataAsync : IpLeakClientTests
        {
            [Test]
            public async Task WhenDomainProvided_ThenReturnResponse()
            {
                const string domainName = "airvpn.org";

                var result = await _sut.GetDomainDataAsync(domainName);
                
                Assert.That(result.RequestQueryType, Is.EqualTo(RequestQueryType.TargetDomainName));
                Assert.That(result.QueryText, Is.EqualTo(domainName));
                Assert.That(result.IpEntries.Count, Is.GreaterThan(0));
            }
        }

        [TestFixture]
        public class GetDnsDataAsync : IpLeakClientTests
        {
            [Test]
            public async Task WhenCalled_ThenReturnResponse()
            {
                var result = await _sut.GetDnsDataAsync();

                Assert.That(result.IsSuccessful, Is.True);
                Assert.That(result.RequestQueryType, Is.EqualTo(RequestQueryType.MyDns));
            }
        }
    }
}