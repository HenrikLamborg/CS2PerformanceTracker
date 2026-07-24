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
    }
}
