namespace downstreem.Dtos.MockDTO
{
    public class LandingPageDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<ActiveProject> ActiveProjects { get; set; }
        public List<BillingPreview> BillingPreview { get; set; }
        public ActivityMTD ActivityMTD { get; set; }
        public GlobalStats GlobalStats { get; set; }
        public List<RecentActivity> RecentActivities { get; set; }
    }
}
