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

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string steamId)
    {
        if (string.IsNullOrWhiteSpace(steamId))
        {
            ViewBag.Error = "Please enter a Steam ID or Steam profile URL.";
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
            RecentMatches = player.RecentMatches
        };

        return View(dashboard);
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
