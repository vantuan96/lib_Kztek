using System;

namespace eazy_library.Models
{
    public class HR_EmployeeDayOffTrackingModel
    {
        public string Id { get; set; }

        public string AccountId { get; set; }

        public int Year { get; set; }

        public double TotalDayOff { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}