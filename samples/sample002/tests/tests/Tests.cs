using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace tests
{
    [TestFixture]
    public class Tests
    {
        private WebApplicationFactory<Web.Startup> _factory;
        private HttpClient _client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _factory = new WebApplicationFactory<Web.Startup>();
        }

        [SetUp]
        public void Setup()
        {
            _client = _factory.CreateClient();
        }

        [Test]
        public async Task ShouldReturnSentText()
        {
            const string payload = "HelloWorld";

            var result = await _client.GetStringAsync($"/echo/{payload}");

            Assert.That(result, Is.EqualTo(payload));
        }
    }
}