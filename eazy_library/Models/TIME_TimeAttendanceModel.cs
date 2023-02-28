using System;

namespace eazy_library.Models
{
    public class TIME_TimeAttendanceModel
    {
        public string Id { get; set; }

        public string AccountId { get; set; }

        public string AccountName { get; set; }

        public string UserId { get; set; }

        public DateTime DateCheckIn { get; set; }

        public DateTime DateCheckOut { get; set; }

        public decimal Penalty { get; set; }

        public string CheckType { get; set; }

        public double TotalWorkHour { get; set; }

        public double TotalWorkDay { get; set; }

        public double TotalMinutesLate { get; set; } //nếu muộn => muộn bao giờ phút

        /* #region  Longitude, Latitude */
        public double Longitude_In { get; set; }

        public double Latitude_In { get; set; }

        public string Location_In { get; set; }

        public double Longitude_Out { get; set; }

        public double Latitude_Out { get; set; }

        public string Location_Out { get; set; }
        /* #endregion */

        public string Note { get; set; }

        public string EventCode { get; set; }
    }
}