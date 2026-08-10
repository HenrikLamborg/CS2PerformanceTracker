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

        var steamProfile = await _steamService.GetPlayerSummary(steamId);

        var profile = await _leetifyService.GetPlayerProfile(steamId);

        var matches = await _leetifyService.GetRecentMatches(steamId);

        if (profile == null)
        {
            return null;
        }

        var recentMatches = matches?
            .Take(10)
            .Select(match =>
            {
        var stats = match.Stats.FirstOrDefault();

        var playerTeam = match.TeamScores.FirstOrDefault(
            t => t.TeamNumber == stats?.InitialTeamNumber);

        var enemyTeam = match.TeamScores.FirstOrDefault(
            t => t.TeamNumber != stats?.InitialTeamNumber);

        return new RecentMatchResponse
        {
            Id = match.Id,
            MapName = match.MapName,
            FinishedAt = match.FinishedAt,

            Kills = stats?.TotalKills ?? 0,
            Deaths = stats?.TotalDeaths ?? 0,

            KdRatio = stats?.KdRatio ?? 0,
            LeetifyRating = stats?.LeetifyRating ?? 0,

            Won = playerTeam != null &&
                  enemyTeam != null &&
                  playerTeam.Score > enemyTeam.Score,

            Score = playerTeam != null && enemyTeam != null
                ? $"{playerTeam.Score}-{enemyTeam.Score}"
                : string.Empty
        };
        })
        .ToList() ?? [];

        var performanceSummary = new PerformanceSummaryResponse
        {
            WinRate = recentMatches.Any()
                ? recentMatches.Count(m => m.Won) * 100.0 / recentMatches.Count
                : 0,

            AverageKd = recentMatches.Any()
                ? recentMatches.Average(m => m.KdRatio)
                : 0,

            AverageKills = recentMatches.Any()
                ? recentMatches.Average(m => m.Kills)
                : 0,

            AverageRating = recentMatches.Any()
                ? recentMatches.Average(m => m.LeetifyRating)
                : 0
        };

        return new PlayerStatsResponse
        {
            SteamId = profile.Steam64Id,
            Username = profile.Name,

            SteamAvatarUrl = steamProfile?.AvatarFull ?? "",
            SteamProfileUrl = steamProfile?.ProfileUrl ?? "",

            FaceitLevel = profile.Ranks.Faceit ?? 0,
            LeetifyRating = profile.Ranks.Leetify ?? 0.0,

            Aim = profile.Rating.Aim,
            Utility = profile.Rating.Utility,
            Positioning = profile.Rating.Positioning,

            ReactionTimeMs = profile.Stats.ReactionTimeMs,
            SprayAccuracy = profile.Stats.SprayAccuracy,
            Preaim = profile.Stats.Preaim,

            RecentMatches = recentMatches,
            PerformanceSummary = performanceSummary
            

        };
    }
}