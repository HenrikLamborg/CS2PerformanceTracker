using CS2PerformanceTracker.Web.Models;

namespace CS2PerformanceTracker.Web.Viewmodels
{
    public class PlayerDashboardViewModel
    {
        public PlayerStatsResponse? Player { get; set; }
        public List<RecentMatchViewModel> RecentMatches { get; set; } = [];

        public PerformanceSummaryViewModel PerformanceSummary { get; set; } = new();
    }
}
