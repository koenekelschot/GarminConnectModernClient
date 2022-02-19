using GarminConnectModernClient.Clients;
using GarminConnectModernClient.Models;
using GarminConnectModernClient.Services;

namespace GarminConnectModernClient.Connectors.Implementations
{
    public class GarminConnectConnector : IGarminConnectConnector
    {
        private readonly IGarminSsoClient _ssoClient;
        private readonly IGarminConnectClient _connectClient;
        private readonly IGarminSessionService _sessionService;

        public GarminConnectConnector(IGarminSsoClient ssoClient, IGarminConnectClient connectClient, IGarminSessionService sessionService)
        {
            _ssoClient = ssoClient;
            _connectClient = connectClient;
            _sessionService = sessionService;
        }

        public async Task<bool> LoginAsync(string username, string password, CancellationToken cancellationToken = default)
        {
            if (_sessionService.IsLoggedIn())
            {
                _ = await LogoutAsync(cancellationToken);
            }

            await _ssoClient.LoginAsync(username, password, cancellationToken);
            return _sessionService.IsLoggedIn();
        }

        public async Task<bool> LogoutAsync(CancellationToken cancellationToken = default)
        {
            if (!_sessionService.IsLoggedIn())
            {
                return true;
            }

            await _ssoClient.LogoutAsync(cancellationToken);
            return !_sessionService.IsLoggedIn();
        }

        public async Task<IList<Activity>> FindActivitiesAsync(CancellationToken cancellationToken = default)
        {
            return await FindActivitiesAsync(new ActivitySearchFilters(), cancellationToken);
        }

        public async Task<IList<Activity>> FindActivitiesAsync(ActivitySearchFilters filters, CancellationToken cancellationToken = default)
        {
            ThrowOnNotLoggedIn();
            return await _connectClient.FindActivitiesAsync(filters, cancellationToken);
        }

        public async Task<IList<Activity>> FindAllActivitiesAsync(CancellationToken cancellationToken = default)
        {
            ThrowOnNotLoggedIn();
            return await _connectClient.FindAllActivitiesAsync(cancellationToken);
        }

        public async Task<Stream?> ExportActivityAsync(long activityId, ExportFormat format, CancellationToken cancellationToken)
        {
            ThrowOnNotLoggedIn();
            return await _connectClient.ExportActivityAsync(activityId, format, cancellationToken);
        }

        private void ThrowOnNotLoggedIn()
        {
            if (!_sessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Please login before requesting activity data");
            }
        }
    }
}
