using CS2PerformanceTracker.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<PlayerStatsService>();
builder.Services.AddControllers();
builder.Services.AddHttpClient<LeetifyService>();
builder.Services.AddHttpClient<SteamService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();