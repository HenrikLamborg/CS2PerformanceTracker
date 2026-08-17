namespace CS2PerformanceTracker.Web.Viewmodels
{
    public class MapPerformanceViewModel
    {
        public string MapName { get; set; } = string.Empty;

        public int MatchesPlayed { get; set; }

        public int Wins { get; set; }

        public double WinRate { get; set; }

        public double AverageKd { get; set; }
    }
}
