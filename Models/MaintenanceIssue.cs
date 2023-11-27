namespace LUSCMaintenance.Models
{
    public class MaintenanceIssue
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int MaintenanceIssueCategoryId { get; set; }
        public MaintenanceIssueCategory MaintenanceIssueCategory { get; set; }
    }
}
