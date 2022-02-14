namespace downstreem.Dtos.MockDTO
{
    public class GlobalStats
    {
        public int TotalUsers { get; set; }
        public int TotalGb { get; set; }
        public int TotalItem { get; set; }
        public int Responsive { get; set; }
        public int NonResponsive { get; set; }
        public int Untagged { get; set; }
        public int Exported { get; set; }
        public double MonthlyTls { get; set; }
        public double PreviousMonthTls { get; set; }
    }
}
