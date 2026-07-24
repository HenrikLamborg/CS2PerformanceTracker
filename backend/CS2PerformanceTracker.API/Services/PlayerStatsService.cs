using CS2PerformanceTracker.API.DTOs;

namespace CS2PerformanceTracker.API.Services;

/// <summary>
/// Responsible for converting the data from the LeetifyService into a PlayerStatsResponse object.
/// </summary>
public class PlayerStatsService
{
    private readonly LeetifyService _leetifyService;

    public PlayerStatsService(LeetifyService leetifyService)
    {
        _leetifyService = leetifyService;
    }

    public async Task<PlayerStatsResponse?> GetPlayerStats(string steamId)
    {
        var profile = await _leetifyService.GetPlayerProfile(steamId);

        if (profile == null)
        {
            return null;
        }

        return new PlayerStatsResponse
        {
            SteamId = profile.Steam64Id,
            Username = profile.Name,
            FaceitLevel = profile.Ranks.Faceit,
            LeetifyRating = profile.Ranks.Leetify,

            Aim = profile.Rating.Aim,
            Utility = profile.Rating.Utility,
            Positioning = profile.Rating.Positioning,

            ReactionTimeMs = profile.Stats.ReactionTimeMs,
            SprayAccuracy = profile.Stats.SprayAccuracy,
            Preaim = profile.Stats.Preaim
        };
    }
}