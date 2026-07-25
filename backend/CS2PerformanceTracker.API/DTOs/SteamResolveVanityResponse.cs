namespace CS2PerformanceTracker.API.DTOs
{
    public class SteamResolveVanityResponse
    {
        public SteamResponse Response { get; set; } = new();
    }

    public class SteamResponse
    {
        public int Success { get; set; }

        public string SteamId { get; set; } = string.Empty;
    }
}
