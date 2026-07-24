using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CS2PerformanceTracker.Web.Models;
using System.Net.Http.Json;

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
        var apiUrl = _configuration["ApiSettings:BaseUrl"];

        var response = await _httpClient.GetAsync(
            $"{apiUrl}/api/stats/{steamId}"
        );

        response.EnsureSuccessStatusCode();

        var player =
            await response.Content.ReadFromJsonAsync<PlayerStatsResponse>();

        return View(player);
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
