// MaintenanceProblemRequest.cs
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using LUSCMaintenance.Models;

namespace LUSCMaintenance.Controllers
{
    public class MaintenanceProblemRequest
    {
        [Required]
        public int MaintenanceIssueCategoryId { get; set; }

        [Required]
        [MaxLength(1)]
        public char Block { get; set; }

        [EnumDataType(typeof(Hostel))]
        public Hostel Hostel { get; set; }

        [Required]
        [Range(100, 999)]
        public int RoomNumber { get; set; }

        [Required]
        public DateTime TimeAvailable { get; set; }


        [Required]
        public IFormFile Image { get; set; }

        public string ImageURL { get; set; }
    }
}
