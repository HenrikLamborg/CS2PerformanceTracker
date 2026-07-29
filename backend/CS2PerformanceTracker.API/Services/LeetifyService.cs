using CS2PerformanceTracker.API.DTOs;
using System.Net.Http.Json;

namespace CS2PerformanceTracker.API.Services;

/// <summary>
/// Responsible for making HTTP requests to the Leetify API and retrieving player profile data.
/// </summary>
public class LeetifyService
{
    // It uses an HttpClient to send requests and an IConfiguration to access configuration settings, such as the API key.
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public LeetifyService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<LeetifyProfileResponse?> GetPlayerProfile(string steam64Id)
    {
        var apiKey = _configuration["Leetify:ApiKey"];

        var request = new HttpRequestMessage(
            HttpMethod.Get,
            $"https://api-public.cs-prod.leetify.com/v3/profile?steam64_id={steam64Id}"
        );

        request.Headers.Add("_leetify_key", apiKey);

        var response = await _httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<LeetifyProfileResponse>();
    }

    public async Task<List<LeetifyMatch>?> GetRecentMatches(string steam64Id)
    {
        var response = await _httpClient.GetAsync(
            $"https://api-public.cs-prod.leetify.com/v3/profile/matches?steam64_id={steam64Id}"
        );

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<List<LeetifyMatch>>();
    }
}