using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LUSCMaintenance.Models
{
    public enum Hostel
    {
        Daniel,
        Dorcas,
        Sarah,
        Abigal,
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

        [Required]
        public int MaintenanceIssueId { get; set; }

        [ForeignKey(nameof(MaintenanceIssueId))]
        public MaintenanceIssue MaintenanceIssue { get; set; }

        [MaxLength(1)] // Block is a single letter
        public char Block { get; set; }

        [EnumDataType(typeof(Hostel))]
        public Hostel Hostel { get; set; }

        [Required]
        [Range(100, 999)] // Room number is three digits
        public int RoomNumber { get; set; }

        public DateTime TimeAvailable { get; set; }

        public bool IsResolved { get; set; } = false;

    }
}
