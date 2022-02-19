using System.Net;

namespace GarminConnectModernClient.Services.Implementations
{
    public class GarminSessionService : IGarminSessionService
    {
        private readonly CookieContainer _cookies;

        private readonly string[] _sessionCookies = new[]
        {
            "GARMIN-SSO",
            "GARMIN-SSO-GUID",
            "GARMIN-SSO-CUST-GUID",
            "SESSION",
            "CASTGC"
        };

        public GarminSessionService()
        {
            _cookies = new CookieContainer();
        }

        CookieContainer IGarminSessionService.Cookies => _cookies;

        public bool IsLoggedIn()
        {
            foreach (var expectedCookie in _sessionCookies)
            {
                if (!_cookies.GetAllCookies().Any(c => c.Name == expectedCookie && !c.Expired))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
