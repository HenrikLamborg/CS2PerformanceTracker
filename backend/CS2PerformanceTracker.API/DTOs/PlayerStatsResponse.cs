namespace CS2PerformanceTracker.API.DTOs
{
    /// <summary>
    /// Represents the response containing player statistics.
    /// </summary>
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

        public List<RecentMatchResponse> RecentMatches { get; set; } = [];

        public PerformanceSummaryResponse PerformanceSummary { get; set; } = new();
    }

    public class RecentMatchResponse
    {
        public string MapName { get; set; } = string.Empty;

        public DateTime FinishedAt { get; set; }

        public int Kills { get; set; }

        public int Deaths { get; set; }

        public double KdRatio { get; set; }

        public double LeetifyRating { get; set; }

        public bool Won { get; set; }

        public string Score { get; set; } = string.Empty;
    }
}
