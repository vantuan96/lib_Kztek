using System;

namespace eazy_library.Models
{
    public class TIME_EmployeeMonthSummaryModel
    {
        public string Id { get; set; }

        public string AccountId { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public double TotalLaborDay { get; set; }

        public double TotalOvertime { get; set; }

        public double TotalDayOff { get; set; }

        public decimal TotalPenalty { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}