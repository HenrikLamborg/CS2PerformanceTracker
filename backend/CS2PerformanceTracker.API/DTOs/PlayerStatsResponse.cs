namespace CS2PerformanceTracker.API.DTOs
{
    public class PlayerStatsResponse
    {
        public string SteamId { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;

        public int FaceitLevel { get; set; }

        public double KillDeathRatio { get; set; }

        public double HeadshotPercentage { get; set; }

        public int TotalKills { get; set; }

        public int TotalDeaths { get; set; }
    }
}
