using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LUSCMaintenance.Models
{
    public class MaintenanceProblem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string WebMail { get; set; }

        public string? ImageURL { get; set; }

        [Required]
        public string Block { get; set; }

        [Required]
        public string Hostel { get; set; } // Changed Hostel to string type

        [Required]
        [Range(100, 999)]
        public int RoomNumber { get; set; }

        public DateTime TimeAvailable { get; set; }

        [Required]
        public DateTime DateComplaintMade { get; set; } = DateTime.UtcNow;

        public bool IsResolved { get; set; } = false;

        // Add navigation property for the join table
        public virtual ICollection<MaintenanceProblemIssue> MaintenanceProblemIssues { get; set; }
    }
}
