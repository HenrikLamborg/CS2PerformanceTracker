using CS2PerformanceTracker.API.DTOs;

namespace CS2PerformanceTracker.API.Services;

/// <summary>
/// Coordinates retrieving player data from Steam and Leetify
/// and converts it into a PlayerStatsResponse object.
/// </summary>
public class PlayerStatsService
{
    private readonly LeetifyService _leetifyService;
    private readonly SteamService _steamService;

    public PlayerStatsService(
        LeetifyService leetifyService,
        SteamService steamService)
    {
        _leetifyService = leetifyService;
        _steamService = steamService;
    }

    public async Task<PlayerStatsResponse?> GetPlayerStats(string input)
    {
        var steamId = await _steamService.ResolveSteamId(input);

        if (steamId == null)
        {
            return null;
        }

        var profile = await _leetifyService.GetPlayerProfile(steamId);

        if (profile == null)
        {
            return null;
        }

        return new PlayerStatsResponse
        {
            SteamId = profile.Steam64Id,
            Username = profile.Name,
            FaceitLevel = profile.Ranks.Faceit ?? 0,
            LeetifyRating = profile.Ranks.Leetify ?? 0.0,

            Aim = profile.Rating.Aim,
            Utility = profile.Rating.Utility,
            Positioning = profile.Rating.Positioning,

            ReactionTimeMs = profile.Stats.ReactionTimeMs,
            SprayAccuracy = profile.Stats.SprayAccuracy,
            Preaim = profile.Stats.Preaim
        };
    }
}