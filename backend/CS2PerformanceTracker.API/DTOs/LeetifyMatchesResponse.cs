using System.Text.Json.Serialization;

namespace CS2PerformanceTracker.API.DTOs
{
    public class LeetifyMatch
    {
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("finished_at")]
        public DateTime FinishedAt { get; set; }

        [JsonPropertyName("map_name")]
        public string MapName { get; set; } = string.Empty;

        [JsonPropertyName("team_scores")]
        public List<LeetifyTeamScore> TeamScores { get; set; } = [];

        public List<LeetifyMatchStats> Stats { get; set; } = [];
    }


    public class LeetifyTeamScore
    {
        [JsonPropertyName("team_number")]
        public int TeamNumber { get; set; }

        public int Score { get; set; }
    }


    public class LeetifyMatchStats
    {
        [JsonPropertyName("steam64_id")]
        public string Steam64Id { get; set; } = string.Empty;

        [JsonPropertyName("initial_team_number")]
        public int InitialTeamNumber { get; set; }

        [JsonPropertyName("total_kills")]
        public int TotalKills { get; set; }

        [JsonPropertyName("total_deaths")]
        public int TotalDeaths { get; set; }

        [JsonPropertyName("kd_ratio")]
        public double KdRatio { get; set; }

        [JsonPropertyName("leetify_rating")]
        public double LeetifyRating { get; set; }
    }
}
