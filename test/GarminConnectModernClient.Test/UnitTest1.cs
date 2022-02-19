using GarminConnectModernClient.Clients.Implementations;
using GarminConnectModernClient.Connectors;
using GarminConnectModernClient.Connectors.Implementations;
using GarminConnectModernClient.Services.Implementations;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GarminConnectModernClient.Test
{
    public class Tests
    {
        private IGarminConnectConnector? _connector;

        [SetUp]
        public void Setup()
        {
            var sessionService = new GarminSessionService();
            var ssoClient = new GarminSsoClient(sessionService);
            var connectClient = new GarminConnectClient(sessionService);

            _connector = new GarminConnectConnector(ssoClient, connectClient, sessionService);
        }

        [Test]
        public async Task Test1()
        {
            _ = await _connector!.LoginAsync("username", "********");
            var result = await _connector.FindAllActivitiesAsync();
            _ = await _connector.LogoutAsync();

            Assert.IsNotNull(result);
        }
    }
}