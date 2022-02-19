using GarminConnectModernClient.Exceptions;
using GarminConnectModernClient.Services;
using RestSharp;
using System.Net;

namespace GarminConnectModernClient.Clients.Implementations
{
    public class GarminSsoClient : IGarminSsoClient, IDisposable
    {
        private readonly IGarminSessionService _sessionService;
        private readonly RestClient _client;
        private bool disposedValue;
        private const string BaseUrl = "https://sso.garmin.com";

        public GarminSsoClient(IGarminSessionService sessionService)
        {
            _sessionService = sessionService;
            _client = new RestClient(new RestClientOptions
            {
                BaseUrl = new Uri(BaseUrl),
                CookieContainer = _sessionService.Cookies
            });

            // Specify Origin header to match Garmin CORS
            // access-control-allow-origin: https://sso.garmin.com
            _client.AddDefaultHeader("Origin", BaseUrl);
        }

        public async Task LoginAsync(string username, string password, CancellationToken cancellationToken)
        {
            // https://sso.garmin.com/sso/signin?service=https://connect.garmin.com/modern/
            var request = new RestRequest("/sso/signin")
                .AddParameter("service", GarminConnectClient.BaseUrl, ParameterType.QueryString)
                .AddParameter("username", username)
                .AddParameter("password", password);
            var response = await _client.ExecutePostAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new GarminSsoException("Invalid sign in. (Passwords are case sensitive.)");
            }

            // Garmin somtimes sends a Moved status code on a succesfull login
            if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Moved)
            {
                throw new GarminSsoException("An unexpected error has occurred.");
            }

            // Make sure the required cookies are present
            if (!_sessionService.IsLoggedIn())
            {
                throw new GarminSsoException("Session cookies not present.");
            }
        }

        public async Task LogoutAsync(CancellationToken cancellationToken)
        {
            // https://sso.garmin.com/sso/logout?service=https://connect.garmin.com/signin
            var request = new RestRequest("/sso/logout")
                .AddParameter("service", GarminConnectClient.BaseUrl, ParameterType.QueryString);
            _ = await _client.ExecutePostAsync(request, cancellationToken);

            // Make sure the required cookies are gone
            if (_sessionService.IsLoggedIn())
            {
                throw new GarminSsoException("Session cookies still present.");
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _client.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
