using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LUSCMaintenance.Models
{
    public enum Hostel
    {
        Daniel,
        Dorcas,
        Sarah,
        Abigail,
        Deborah,
        Joseph,
        Isaac,
        Abraham
    }

    public class MaintenanceProblem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string WebMail { get; set; }

        public string? ImageURL { get; set; }

        [Required]
        public string Block { get; set; }

        [EnumDataType(typeof(Hostel))]
        public Hostel Hostel { get; set; }

        [Required]
        [Range(100, 999)]
        public int RoomNumber { get; set; }

        public DateTime TimeAvailable { get; set; }

        [Required]
        public DateTime DateComplaintMade { get; set; } = DateTime.UtcNow;

        public bool IsResolved { get; set; } = false;

        public virtual ICollection<MaintenanceIssue> MaintenanceProblemIssues { get; set; }
    }
}
