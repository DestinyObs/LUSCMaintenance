using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using LUSCMaintenance.Models;

namespace LUSCMaintenance.Controllers
{
    public class MaintenanceProblemRequest
    {
        public IFormFile? Image { get; set; }

        [Required]
        [MaxLength(1)]
        public string Block { get; set; }

        [EnumDataType(typeof(Hostel))]
        public Hostel Hostel { get; set; }

        [Required]
        [Range(100, 999)]
        public int RoomNumber { get; set; }

        [Required]
        public DateTime TimeAvailable { get; set; }

        [Required]
        public List<int> MaintenanceIssueIds { get; set; }

    }
}
