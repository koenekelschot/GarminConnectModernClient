namespace GarminConnectModernClient.Models
{
	// see: https://github.com/cyberjunky/python-garminconnect/blob/master/garminconnect/__init__.py#L522
	public class ActivitySearchFilters
    {
		public string Search { get; set; } = "";
		public int Start { get; set; } = 0;
		public int Limit { get; set; } = 20;
		public bool Favorite { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public ActivitySearchType? ActivityType { get; set; }
	}
}
