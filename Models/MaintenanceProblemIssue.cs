namespace LUSCMaintenance.Models
{

    public class MaintenanceProblemIssue
    {
        public int Id { get; set; }
        public int MaintenanceProblemId { get; set; }
        public MaintenanceProblem MaintenanceProblem { get; set; }
        public int MaintenanceIssueId { get; set; }
        public MaintenanceIssue MaintenanceIssue { get; set; }
    }
}
