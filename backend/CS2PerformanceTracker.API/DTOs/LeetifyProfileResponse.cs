namespace CS2PerformanceTracker.API.DTOs;
using System.Text.Json.Serialization;

/// <summary>
/// Respresents the response containing a player's profile information from Leetify.
/// </summary>
public class LeetifyProfileResponse
{
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("steam64_id")]
    public string Steam64Id { get; set; } = string.Empty;

    [JsonPropertyName("total_matches")]
    public int TotalMatches { get; set; }

    public double Winrate { get; set; }

    public LeetifyRanks Ranks { get; set; } = new();

    public LeetifyRating Rating { get; set; } = new();

    public LeetifyStats Stats { get; set; } = new();
}

public class LeetifyRanks
{
    public double? Leetify { get; set; }

    public int? Premier { get; set; }

    public int? Faceit { get; set; }

    public int? FaceitElo { get; set; }
}


public class LeetifyRating
{
    public double Aim { get; set; }

    public double Positioning { get; set; }

    public double Utility { get; set; }

    public double Clutch { get; set; }

    public double Opening { get; set; }
}


public class LeetifyStats
{
    [JsonPropertyName("reaction_time_ms")]
    public double ReactionTimeMs { get; set; }

    [JsonPropertyName("spray_accuracy")]
    public double SprayAccuracy { get; set; }

    public double Preaim { get; set; }

    public double CounterStrafingGoodShotsRatio { get; set; }

    public double FlashbangHitFoePerFlashbang { get; set; }

    public double FlashbangLeadingToKill { get; set; }
}