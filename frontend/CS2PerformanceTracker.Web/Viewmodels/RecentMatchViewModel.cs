namespace CS2PerformanceTracker.Web.Viewmodels
{
    public class RecentMatchViewModel
    {
        public string MapName { get; set; } = string.Empty;

        public DateTime FinishedAt { get; set; }

        public int Kills { get; set; }

        public int Deaths { get; set; }

        public double KdRatio { get; set; }

        public double LeetifyRating { get; set; }
    }
}
