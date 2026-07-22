using CS2PerformanceTracker.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS2PerformanceTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatsController : ControllerBase
{
    private readonly PlayerStatsService _playerStatsService;

    public StatsController(PlayerStatsService playerStatsService)
    {
        _playerStatsService = playerStatsService;
    }

    [HttpGet("{steamId}")]
    public async Task<IActionResult> GetStats(string steamId)
    {
        var stats = await _playerStatsService.GetPlayerStats(steamId);

        if (stats == null)
        {
            return NotFound();
        }

        return Ok(stats);
    }
}