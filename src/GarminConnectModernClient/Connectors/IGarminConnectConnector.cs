using GarminConnectModernClient.Models;

namespace GarminConnectModernClient.Connectors
{
    public interface IGarminConnectConnector
    {
        Task<bool> LoginAsync(string username, string password, CancellationToken cancellationToken = default);
        Task<bool> LogoutAsync(CancellationToken cancellationToken = default);

        Task<IList<Activity>> FindActivitiesAsync(CancellationToken cancellationToken = default);
        Task<IList<Activity>> FindActivitiesAsync(ActivitySearchFilters filters, CancellationToken cancellationToken = default);
        Task<IList<Activity>> FindAllActivitiesAsync(CancellationToken cancellationToken = default);
        Task<Stream?> ExportActivityAsync(long activityId, ExportFormat format, CancellationToken cancellationToken = default);
    }
}
