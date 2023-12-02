using System;
using LUSCMaintenance.Models;

namespace LUSCMaintenance.Controllers
{
    public class MaintenanceProblemResponse
    {
        public int Id { get; set; }
        public string WebMail { get; set; }
        public string ImageURL { get; set; }
        public int MaintenanceIssueId { get; set; }
        public char Block { get; set; }
        public Hostel Hostel { get; set; }
        public int RoomNumber { get; set; }
        public DateTime TimeAvailable { get; set; }
        public DateTime DateComplaintMade { get; set; }
        public bool IsResolved { get; set; }
    }
}
