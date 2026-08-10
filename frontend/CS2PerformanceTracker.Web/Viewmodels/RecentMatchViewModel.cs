namespace CS2PerformanceTracker.Web.Viewmodels
{
    public class RecentMatchViewModel
    {
        public string Id { get; set; } = string.Empty;

        public string MapName { get; set; } = string.Empty;

        public DateTime FinishedAt { get; set; }

        public int Kills { get; set; }

        public int Deaths { get; set; }

        public double KdRatio { get; set; }

        public double LeetifyRating { get; set; }

        public bool Won { get; set; }

        public string Score { get; set; } = string.Empty;

        public int Mvps { get; set; }

        public double Dpr { get; set; }

        public int TotalAssists { get; set; }

        public int TotalDamage { get; set; }

        public int TotalHsKills { get; set; }

        public double Accuracy { get; set; }

        public double AccuracyHead { get; set; }

        public double ReactionTime { get; set; }

        public double CounterStrafingGoodRatio { get; set; }

        public double Preaim { get; set; }

        public double SprayAccuracy { get; set; }

        public int HeThrown { get; set; }

        public int MolotovThrown { get; set; }

        public int SmokeThrown { get; set; }

        public int FlashbangThrown { get; set; }

        public int FlashbangHitFoe { get; set; }

        public int FlashbangLeadingToKill { get; set; }

        public int FlashAssist { get; set; }

        public double HeFoesDamageAvg { get; set; }

        public double UtilityOnDeathAvg { get; set; }
    }
}
