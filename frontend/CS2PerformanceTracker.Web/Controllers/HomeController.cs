using CS2PerformanceTracker.Web.Models;
using CS2PerformanceTracker.Web.Viewmodels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CS2PerformanceTracker.Web.Controllers;

public class HomeController : Controller
{
    // Inject HttpClient into the controller
    private readonly HttpClient _httpClient;

    // Inject IConfiguration into the controller
    private readonly IConfiguration _configuration;

    // Constructor to initialize the HttpClient and IConfiguration
    public HomeController(
    HttpClient httpClient,
    IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string? steamId)
    {
        if (string.IsNullOrWhiteSpace(steamId))
        {
            if (Request.Query.ContainsKey("steamId"))
            {
                ViewBag.Error = "Please enter a Steam ID or Steam profile URL.";
            }

            return View();
        }

        var apiUrl = _configuration["ApiSettings:BaseUrl"];

        var response = await _httpClient.GetAsync(
            $"{apiUrl}/api/stats/{Uri.EscapeDataString(steamId)}"
        );

        // Check if the response is successful
        if (!response.IsSuccessStatusCode)
        {
            ViewBag.Error = "Could not retrieve player data.";
            return View();
        }

        var player =
            await response.Content.ReadFromJsonAsync<PlayerStatsResponse>();

        if (player == null)
        {
            ViewBag.Error = "Found no Leetify-profile with this SteamID.";
            return View();
        }

        var dashboard = new PlayerDashboardViewModel
        {
            Player = player,
            RecentMatches = player.RecentMatches,
            PerformanceSummary = player.PerformanceSummary
        };

        return View(dashboard);
    }

    public async Task<IActionResult> Match(string steamId, string id)
    {
        var apiUrl = _configuration["ApiSettings:BaseUrl"];

        var response = await _httpClient.GetAsync(
            $"{apiUrl}/api/stats/{Uri.EscapeDataString(steamId)}"
        );

        if (!response.IsSuccessStatusCode)
        {
            return NotFound();
        }

        var player =
            await response.Content.ReadFromJsonAsync<PlayerStatsResponse>();

        if (player == null)
        {
            return NotFound();
        }

        var match = player.RecentMatches
            .FirstOrDefault(m => m.Id == id);

        if (match == null)
        {
            return NotFound();
        }

        var viewModel = new MatchDetailsViewModel
        {
            MapName = match.MapName,
            FinishedAt = match.FinishedAt,

            SteamId = player.SteamId,

            Kills = match.Kills,
            Deaths = match.Deaths,

            KdRatio = match.KdRatio,
            LeetifyRating = match.LeetifyRating,

            Mvps = match.Mvps,
            Dpr = match.Dpr,
            TotalAssists = match.TotalAssists,
            TotalDamage = match.TotalDamage,
            TotalHsKills = match.TotalHsKills,

            Accuracy = match.Accuracy,
            AccuracyHead = match.AccuracyHead,
            ReactionTime = match.ReactionTime,
            CounterStrafingGoodRatio = match.CounterStrafingGoodRatio,
            Preaim = match.Preaim,
            SprayAccuracy = match.SprayAccuracy,

            HeThrown = match.HeThrown,
            MolotovThrown = match.MolotovThrown,
            SmokeThrown = match.SmokeThrown,
            FlashbangThrown = match.FlashbangThrown,
            FlashbangHitFoe = match.FlashbangHitFoe,
            FlashbangLeadingToKill = match.FlashbangLeadingToKill,
            FlashAssist = match.FlashAssist,
            HeFoesDamageAvg = match.HeFoesDamageAvg,
            UtilityOnDeathAvg = match.UtilityOnDeathAvg,

            Won = match.Won,
            Score = match.Score
        };

        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
