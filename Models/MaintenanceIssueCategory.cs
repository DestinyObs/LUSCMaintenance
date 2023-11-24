using System.ComponentModel.DataAnnotations;

namespace LUSCMaintenance.Models
{
    public class MaintenanceIssueCategory
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
