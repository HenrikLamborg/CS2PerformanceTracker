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

        public List<MapPerformanceResponse> MapPerformance { get; set; } = [];
    }

    public class RecentMatchResponse
    {
        public string Id { get; set; } = string.Empty;

        public string MapName { get; set; } = string.Empty;

        public DateTime FinishedAt { get; set; }

        public int Kills { get; set; }

        public int Deaths { get; set; }

        public double KdRatio { get; set; }

        public double LeetifyRating { get; set; }

        public bool Won { get; set; }

        public string Score { get; set; } = string.Empty;

        public int Mvps { get; set; }

        public double Dpr { get; set; }

        public int TotalAssists { get; set; }

        public int TotalDamage { get; set; }

        public int TotalHsKills { get; set; }

        public double Accuracy { get; set; }

        public double AccuracyHead { get; set; }

        public double ReactionTime { get; set; }

        public double CounterStrafingGoodRatio { get; set; }

        public double Preaim { get; set; }

        public double SprayAccuracy { get; set; }

        public int HeThrown { get; set; }

        public int MolotovThrown { get; set; }

        public int SmokeThrown { get; set; }

        public int FlashbangThrown { get; set; }

        public int FlashbangHitFoe { get; set; }

        public int FlashbangLeadingToKill { get; set; }

        public int FlashAssist { get; set; }

        public double HeFoesDamageAvg { get; set; }

        public double UtilityOnDeathAvg { get; set; }

    }

    public class MapPerformanceResponse
    {
        public string MapName { get; set; } = string.Empty;

        public int MatchesPlayed { get; set; }

        public int Wins { get; set; }

        public double WinRate { get; set; }

        public double AverageKd { get; set; }
    }
}
