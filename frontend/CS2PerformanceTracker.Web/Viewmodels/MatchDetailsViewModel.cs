namespace CS2PerformanceTracker.Web.Viewmodels
{
    public class MatchDetailsViewModel
    {
        public string MapName { get; set; } = string.Empty;

        public DateTime FinishedAt { get; set; }

        public bool Won { get; set; }

        public string Score { get; set; } = string.Empty;

        public int Kills { get; set; }

        public int Deaths { get; set; }

        public double KdRatio { get; set; }

        public double LeetifyRating { get; set; }
    }
}
