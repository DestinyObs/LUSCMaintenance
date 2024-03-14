using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace LUSCMaintenance.Controllers
{
    public class MaintenanceProblemRequest
    {

        public string UserWebMail { get; set; }
        public IFormFile? Image { get; set; }

        [Required]
        [MaxLength(1)]
        public string Block { get; set; }

        [Required]
        public string Hostel { get; set; } // Change Hostel to string type

        [Required]
        [Range(100, 999)]
        public int RoomNumber { get; set; }

        [Required]
        public DateTime TimeAvailable { get; set; }

        [Required]
        public List<int> MaintenanceIssueIds { get; set; }
    }
}
