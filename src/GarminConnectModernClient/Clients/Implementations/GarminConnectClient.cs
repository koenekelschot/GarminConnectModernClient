using GarminConnectModernClient.Models;
using GarminConnectModernClient.Services;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System.Reflection;

namespace GarminConnectModernClient.Clients.Implementations
{
    public class GarminConnectClient : IGarminConnectClient, IDisposable
    {
        private readonly IGarminSessionService _sessionService;
        private readonly RestClient _client;
        private bool disposedValue;
        public const string BaseUrl = "https://connect.garmin.com/modern";

        public GarminConnectClient(IGarminSessionService sessionService)
        {
            _sessionService = sessionService;
            _client = new RestClient(new RestClientOptions
            {
                BaseUrl = new Uri(BaseUrl),
                CookieContainer = _sessionService.Cookies
            });
            _client.AddDefaultHeader("NK", "NT"); // Garmin requires this header to be present
            _client.UseNewtonsoftJson();
        }

        public async Task<IList<Activity>> FindActivitiesAsync(ActivitySearchFilters filters, CancellationToken cancellationToken)
        {
            var request = new RestRequest("/proxy/activitylist-service/activities/search/activities");
            AddFiltersAsParameters(request, filters);

            var result = await _client.ExecuteGetAsync<List<Activity>>(request, cancellationToken);

            return result.Data ?? new List<Activity>(0);
        }

        public async Task<IList<Activity>> FindAllActivitiesAsync(CancellationToken cancellationToken)
        {
            var filter = new ActivitySearchFilters { Start = 0 };
            var allActivities = new List<Activity>(0);
            
            while (true)
            {
                var activities = await FindActivitiesAsync(filter, cancellationToken);
                allActivities.AddRange(activities);
                filter.Start += filter.Limit;
                if (activities.Count < filter.Limit)
                {
                    break;
                }
            }

            return allActivities;
        }

        public async Task<Stream?> ExportActivityAsync(long activityId, ExportFormat format, CancellationToken cancellationToken)
        {
            var exportUrl = $"/proxy/download-service/files/activity/{activityId}";
            if (format != ExportFormat.Original)
            {
                exportUrl = $"/proxy/download-service/export/{format.ToString().ToLower()}/activity/{activityId}";
            }

            var request = new RestRequest(exportUrl);
            return await _client.DownloadStreamAsync(request, cancellationToken);
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

        private static void AddFiltersAsParameters(RestRequest request, ActivitySearchFilters filters)
        {
            var properties = filters.GetType().GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(filters, null);

                if (value != null)
                {
                    request.AddParameter(ToFirstLowercase(property.Name), GetParameterValue(property, value));
                }
            }
        }

        private static string GetParameterValue(PropertyInfo property, object value)
        {
            if (property.PropertyType == typeof(bool))
            {
                return value.ToString() == bool.TrueString ? "1" : "0";
            }
            if (property.PropertyType == typeof(DateTime?))
            {
                return ((DateTime)value).ToString("yyyy-MM-dd");
            }
            if (property.PropertyType == typeof(ActivitySearchType?))
            {
                var splitted = ((ActivitySearchType)value).ToString().Split('_');
                var stringValue = ToFirstLowercase(splitted[0]);
                for (var i = 1; i < splitted.Length; i++)
                {
                    stringValue += '_' + ToFirstLowercase(splitted[i]);
                }
                return stringValue;
            }

            return value.ToString() ?? string.Empty;
        }

        private static string ToFirstLowercase(string input)
        {
            return char.ToLower(input[0]) + input[1..];
        }
    }
}
