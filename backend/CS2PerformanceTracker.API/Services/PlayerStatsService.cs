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

            Mvps = stats?.Mvps ?? 0,
            Dpr = stats?.Dpr ?? 0,
            TotalAssists = stats?.TotalAssists ?? 0,
            TotalDamage = stats?.TotalDamage ?? 0,
            TotalHsKills = stats?.TotalHsKills ?? 0,

            Accuracy = stats?.Accuracy ?? 0,
            AccuracyHead = stats?.AccuracyHead ?? 0,
            ReactionTime = stats?.ReactionTime ?? 0,
            CounterStrafingGoodRatio = stats?.CounterStrafingGoodRatio ?? 0,
            Preaim = stats?.Preaim ?? 0,
            SprayAccuracy = stats?.SprayAccuracy ?? 0,

            HeThrown = stats?.HeThrown ?? 0,
            MolotovThrown = stats?.MolotovThrown ?? 0,
            SmokeThrown = stats?.SmokeThrown ?? 0,
            FlashbangThrown = stats?.FlashbangThrown ?? 0,
            FlashbangHitFoe = stats?.FlashbangHitFoe ?? 0,
            FlashbangLeadingToKill = stats?.FlashbangLeadingToKill ?? 0,
            FlashAssist = stats?.FlashAssist ?? 0,
            HeFoesDamageAvg = stats?.HeFoesDamageAvg ?? 0,
            UtilityOnDeathAvg = stats?.UtilityOnDeathAvg ?? 0,

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