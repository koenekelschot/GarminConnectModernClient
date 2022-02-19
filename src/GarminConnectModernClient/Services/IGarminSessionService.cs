using System.Net;

namespace GarminConnectModernClient.Services
{
    public interface IGarminSessionService
    {
        internal CookieContainer Cookies { get; }
        bool IsLoggedIn();
    }
}
