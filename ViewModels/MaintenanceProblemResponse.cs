using LUSCMaintenance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LUSCMaintenance.DTOs
{

    public class MaintenanceProblemResponse
    {
        public int Id { get; set; }
        public string WebMail { get; set; }
        public string ImageUrl { get; set; }
        public string Block { get; set; }
        public string Hostel { get; set; }
        public int RoomNumber { get; set; }
        public DateTime TimeAvailable { get; set; }
        public DateTime DateComplaintMade { get; set; }
        public bool IsResolved { get; set; }
        public List<int> MaintenanceIssueIds { get; set; }
    }
}
