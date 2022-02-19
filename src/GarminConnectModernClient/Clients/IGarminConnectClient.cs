using GarminConnectModernClient.Models;

namespace GarminConnectModernClient.Clients
{
    public interface IGarminConnectClient
    {
        Task<IList<Activity>> FindActivitiesAsync(ActivitySearchFilters filters, CancellationToken cancellationToken);
        Task<IList<Activity>> FindAllActivitiesAsync(CancellationToken cancellationToken);
        Task<Stream?> ExportActivityAsync(long activityId, ExportFormat format, CancellationToken cancellationToken);
    }
}
