using CS2PerformanceTracker.Web.Viewmodels;

namespace CS2PerformanceTracker.Web.Models
{
    public class PlayerStatsResponse
    {
        public string SteamId { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;

        public int FaceitLevel { get; set; }

        public double LeetifyRating { get; set; }

        public double Aim { get; set; }

        public double Utility { get; set; }

        public double Positioning { get; set; }

        public double ReactionTimeMs { get; set; }

        public double SprayAccuracy { get; set; }

        public double Preaim { get; set; }

        public string SteamAvatarUrl { get; set; } = string.Empty;

        public string SteamProfileUrl { get; set; } = string.Empty;

        public List<RecentMatchViewModel> RecentMatches { get; set; } = [];

        public PerformanceSummaryViewModel PerformanceSummary { get; set; } = new();
    }
}
