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

        [JsonPropertyName("mvps")]
        public int Mvps { get; set; }

        [JsonPropertyName("dpr")]
        public double Dpr { get; set; }

        [JsonPropertyName("total_assists")]
        public int TotalAssists { get; set; }

        [JsonPropertyName("total_damage")]
        public int TotalDamage { get; set; }

        [JsonPropertyName("total_hs_kills")]
        public int TotalHsKills { get; set; }

        [JsonPropertyName("accuracy")]
        public double Accuracy { get; set; }

        [JsonPropertyName("accuracy_head")]
        public double AccuracyHead { get; set; }

        [JsonPropertyName("reaction_time")]
        public double ReactionTime { get; set; }

        [JsonPropertyName("counter_strafing_shots_good_ratio")]
        public double CounterStrafingGoodRatio { get; set; }

        [JsonPropertyName("preaim")]
        public double Preaim { get; set; }

        [JsonPropertyName("spray_accuracy")]
        public double SprayAccuracy { get; set; }

        [JsonPropertyName("he_thrown")]
        public int HeThrown { get; set; }

        [JsonPropertyName("molotov_thrown")]
        public int MolotovThrown { get; set; }

        [JsonPropertyName("smoke_thrown")]
        public int SmokeThrown { get; set; }

        [JsonPropertyName("flashbang_thrown")]
        public int FlashbangThrown { get; set; }

        [JsonPropertyName("flashbang_hit_foe")]
        public int FlashbangHitFoe { get; set; }

        [JsonPropertyName("flashbang_leading_to_kill")]
        public int FlashbangLeadingToKill { get; set; }

        [JsonPropertyName("flash_assist")]
        public int FlashAssist { get; set; }

        [JsonPropertyName("he_foes_damage_avg")]
        public double HeFoesDamageAvg { get; set; }

        [JsonPropertyName("utility_on_death_avg")]
        public double UtilityOnDeathAvg { get; set; }
    }
}
