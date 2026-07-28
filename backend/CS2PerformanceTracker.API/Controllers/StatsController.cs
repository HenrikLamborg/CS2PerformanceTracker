using CS2PerformanceTracker.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS2PerformanceTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatsController : ControllerBase
{
    private readonly PlayerStatsService _playerStatsService;
    private readonly SteamService _steamService;

    public StatsController(PlayerStatsService playerStatsService, SteamService steamService)
    {
        _playerStatsService = playerStatsService;
        _steamService = steamService;
    }

    [HttpGet("{steamId}")]
    public async Task<IActionResult> GetStats(string steamId)
    {
        if (string.IsNullOrWhiteSpace(steamId))
        {
            return BadRequest("Steam ID or Steam profile URL is required.");
        }

        var stats = await _playerStatsService.GetPlayerStats(steamId);

        if (stats == null)
        {
            return NotFound();
        }

        return Ok(stats);
    }

    [HttpGet("steam/{steamId}")]
    public async Task<IActionResult> GetSteamProfile(string steamId)
    {
        var player = await _steamService.GetPlayerSummary(steamId);

        if (player == null)
        {
            return NotFound();
        }

        return Ok(player);
    }
}