namespace CS2PerformanceTracker.API.DTOs
{
    public class SteamPlayerSummaryResponse
    {
        public SteamPlayerSummaryData Response { get; set; } = new();
    }

    public class SteamPlayerSummaryData
    {
        public List<SteamPlayer> Players { get; set; } = [];
    }

    public class SteamPlayer
    {
        public string AvatarFull { get; set; } = string.Empty;

        public string ProfileUrl { get; set; } = string.Empty;
    }
}
