using CS2PerformanceTracker.API.DTOs;

namespace CS2PerformanceTracker.API.Services
{
    public class SteamService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public SteamService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        // This method resolves a Steam ID from the given input. It checks if the input is a valid Steam ID (SteamID64).
        public async Task<string?> ResolveSteamId(string input)
        {
            input = input.Trim();
            input = Uri.UnescapeDataString(input); // Unescape any URL-encoded characters

            // Check if the input is a valid Steam ID (SteamID64)
            // SteamID64 is a 64-bit unsigned integer, so we can check if the input can be parsed as ulong
            // If it can be parsed as ulong, we assume it's a valid Steam ID and return it
            if (ulong.TryParse(input, out _))
            {
                return input;
            }

            // Check if the input is a Steam profile URL
            // Steam profile URLs can be in the format of "https://steamcommunity.com/profiles/{SteamID64}"
            // We extract the SteamID64 from the URL and return it if it's valid
            if (input.Contains("steamcommunity.com/profiles/"))
            {
                var profileId = input.TrimEnd('/').Split('/').Last();
                if (ulong.TryParse(profileId, out _))
                {
                    return profileId;
                }
            }

            // Check if the input is a Steam vanity URL
            // Steam vanity URLs can be in the format of "https://steamcommunity.com/id/{vanityName}"
            // We need to resolve the vanity name to a SteamID64 using the Steam Web API
            if (input.Contains("steamcommunity.com/id/"))
            {
                var vanityName = input.TrimEnd('/').Split('/').Last();

                var apiKey = _configuration["Steam:ApiKey"];

                var request = new HttpRequestMessage(
                    HttpMethod.Get,
                    $"https://api.steampowered.com/ISteamUser/ResolveVanityURL/v1/?key={apiKey}&vanityurl={vanityName}"
                );

                var response = await _httpClient.SendAsync(request);

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<SteamResolveVanityResponse>();

                if (result?.Response.Success == 1)
                {
                    return result.Response.SteamId;
                }

                return null;
            }

            return null;
        }
    }
}
