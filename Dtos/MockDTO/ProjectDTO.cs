namespace downstreem.Dtos.MockDTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalItems { get; set; }
        public int TotalGb { get; set; }
        public int Responsive { get; set; }
        public int NonResponsive { get; set; }
        public int Privileged { get; set; }
        public int Untagged { get; set; }
        public int Exported { get; set; }
        public string LastAtivities { get; set; }
        public ActivityMTD ActivityMtd { get; set; }
        public DataType DataType { get; set; }
        public List<RecentActivity> RecentActivities { get; set; }
        public List<Custodian> Custodians { get; set; }
    }
}
