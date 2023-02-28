using System;

namespace eazy_library.Helpers
{
    // Dinh dang thoi gian
    public enum DatetimeFormat
    {
        DDMMYY = 1, // Ngay, thang, nam
        YYMMDD = 2, // Nam, thang, ngay
        MMDDYY = 3  // Thang, ngay, nam
    }

    public enum DateInterval
    {
        Year,
        Month,
        Weekday,
        Day,
        Hour,
        Minute,
        Second
    } 

    public class DateUI
    {
        // Chuyen doi dinh dang thoi gian
        public static string ToShortDateString(DateTime dt, DatetimeFormat format)
        {
            switch (format)
            {
                case DatetimeFormat.DDMMYY:
                    return dt.Day + "/" + dt.Month + "/" + dt.Year + " " + dt.Hour + ":" + dt.Minute;
                case DatetimeFormat.MMDDYY:
                    return dt.Month + "/" + dt.Day + "/" + dt.Year + " " + dt.Hour + ":" + dt.Minute;
                case DatetimeFormat.YYMMDD:
                    return dt.Year + "/" + dt.Month + "/" + dt.Day + " " + dt.Hour + ":" + dt.Minute;
            }
            return "";
        }

        // Chuyen doi dinh dang thoi gian
        public static string ToShortDateString(string date, DatetimeFormat format)
        {
            DateTime dt = Convert.ToDateTime(date);
            switch (format)
            {
                case DatetimeFormat.DDMMYY:
                    return dt.Day + "/" + dt.Month + "/" + dt.Year + " " + dt.Hour + ":" + dt.Minute;
                case DatetimeFormat.MMDDYY:
                    return dt.Month + "/" + dt.Day + "/" + dt.Year + " " + dt.Hour + ":" + dt.Minute;
                case DatetimeFormat.YYMMDD:
                    {
                        return dt.Year + "/" + dt.Month + "/" + dt.Day + " " + dt.Hour + ":" + dt.Minute;
                    }
            }
            return "";
        }

        public static long DateDiff(DateInterval interval, DateTime date1, DateTime date2)
        {
            TimeSpan ts = date2.Subtract(date1);
            int datediff = 0;
            for (int i = 1; i < 5000; i++)
            {
                if (date1.AddDays(i).ToString("yyyy/MM/dd") == date2.ToString("yyyy/MM/dd"))
                {
                    datediff = i;
                    break;
                }
            }
            switch (interval)
            {
                case DateInterval.Year:
                    return date2.Year - date1.Year;
                case DateInterval.Month:
                    return (date2.Month - date1.Month) + (12 * (date2.Year - date1.Year));
                case DateInterval.Weekday:
                    return datediff / 7;
                case DateInterval.Day:
                    return datediff; // Fix(ts.TotalDays);
                case DateInterval.Hour:
                    return Fix(ts.TotalHours);
                case DateInterval.Minute:
                    return Fix(ts.TotalMinutes);
                default:
                    return Fix(ts.TotalSeconds);
            }
        }

        private static long Fix(double Number)
        {
            if (Number >= 0)
            {
                return (long)Math.Floor(Number);
            }
            return (long)Math.Ceiling(Number);
        }

        public static string GetDayOfWeek(DateTime dt)
        {
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "Thứ 2";
                case DayOfWeek.Tuesday:
                    return "Thứ 3";
                case DayOfWeek.Wednesday:
                    return "Thứ 4";
                case DayOfWeek.Thursday:
                    return "Thứ 5";
                case DayOfWeek.Friday:
                    return "Thứ 6";
                case DayOfWeek.Saturday:
                    return "Thứ 7";
                case DayOfWeek.Sunday:
                    return "Chủ nhật";
            }
            return "";
        }

        // Get day of week
        public static int GetDayOfWeekInNumber(DateTime dates)
        {
            switch (dates.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return 1;
                case DayOfWeek.Monday:
                    return 2;
                case DayOfWeek.Tuesday:
                    return 3;
                case DayOfWeek.Wednesday:
                    return 4;
                case DayOfWeek.Thursday:
                    return 5;
                case DayOfWeek.Friday:
                    return 6;
                case DayOfWeek.Saturday:
                    return 7;
                default:
                    return -1;
            }
        }

        // Get day of week
        public static int GetDayOfWeekInNumber1(DateTime dates)
        {
            switch (dates.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return 1;
                case DayOfWeek.Tuesday:
                    return 2;
                case DayOfWeek.Wednesday:
                    return 3;
                case DayOfWeek.Thursday:
                    return 4;
                case DayOfWeek.Friday:
                    return 5;
                case DayOfWeek.Saturday:
                    return 6;
                case DayOfWeek.Sunday:
                    return 7;
                default:
                    return -1;
            }
        }

        // Get day of week
        public static int GetDayOfWeekInNumber2(DateTime dates)
        {
            switch (dates.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return 0;
                case DayOfWeek.Monday:
                    return 1;
                case DayOfWeek.Tuesday:
                    return 2;
                case DayOfWeek.Wednesday:
                    return 3;
                case DayOfWeek.Thursday:
                    return 4;
                case DayOfWeek.Friday:
                    return 5;
                case DayOfWeek.Saturday:
                    return 6;
                default:
                    return -1;
            }
        }

        // Get day of week (DS3000)
        public static int GetDayOfWeekInNumberDS3000(DateTime dates)
        {
            switch (dates.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return 0;
                case DayOfWeek.Monday:
                    return 32;
                case DayOfWeek.Tuesday:
                    return 64;
                case DayOfWeek.Wednesday:
                    return 96;
                case DayOfWeek.Thursday:
                    return 128;
                case DayOfWeek.Friday:
                    return 160;
                case DayOfWeek.Saturday:
                    return 192;
                default:
                    return 0;
            }
        }

        // Get time number in Minute (time string format HH:MM)
        public static int GetTimeNumber(string timeString)
        {
            return Convert.ToInt32(timeString.Substring(0, 2)) * 60 + Convert.ToInt32(timeString.Substring(3, 2));
        }

        // Get time string(time string format HH:MM)
        public static string GetTimeString(int timeNumber)
        {
            int hour = timeNumber / 60;
            int minute = timeNumber - hour * 60;
            return (hour.ToString("00") + ":" + minute.ToString("00"));
        }

        public static long DateDiff_108(DateInterval interval, DateTime date1, DateTime date2)
        {
            TimeSpan ts = date2.Subtract(date1);
            int datediff = 0;
            for (int i = 1; i < 5000; i++)
            {
                if (date1.AddDays(i) >= DateTime.Parse(date2.ToString("yyyy/MM/dd 03:30")))
                {
                    datediff = i;
                    break;
                }
            }
            switch (interval)
            {
                case DateInterval.Year:
                    return date2.Year - date1.Year;
                case DateInterval.Month:
                    return (date2.Month - date1.Month) + (12 * (date2.Year - date1.Year));
                case DateInterval.Weekday:
                    return datediff / 7;
                case DateInterval.Day:
                    return datediff; // Fix(ts.TotalDays);
                case DateInterval.Hour:
                    return Fix(ts.TotalHours);
                case DateInterval.Minute:
                    return Fix(ts.TotalMinutes);
                default:
                    return Fix(ts.TotalSeconds);
            }
        }
        public enum FrequencyType
        {
            None = 0,
            Daily = 1,
            Weekly = 2,
            Monthly = 3,
            Quarterly = 4,
            Annually = 5,
        }
        private static string[] GetRange(FrequencyType frequency, DateTime dateToCheck, string format)
        {
            string[] result = new string[2];
            try
            {
                DateTime dateRangeBegin = dateToCheck;
                TimeSpan duration = new TimeSpan(0, 0, 0, 0); //One day 
                DateTime dateRangeEnd = DateTime.Today.Add(duration);

                switch (frequency)
                {
                    case FrequencyType.Daily:
                        dateRangeBegin = dateToCheck;
                        dateRangeEnd = dateRangeBegin;
                        break;

                    case FrequencyType.Weekly:
                        dateRangeBegin = dateToCheck.AddDays(-(int)dateToCheck.DayOfWeek);
                        dateRangeEnd = dateToCheck.AddDays(6 - (int)dateToCheck.DayOfWeek);
                        break;

                    case FrequencyType.Monthly:
                        duration = new TimeSpan(DateTime.DaysInMonth(dateToCheck.Year, dateToCheck.Month) - 1, 0, 0, 0);
                        dateRangeBegin = dateToCheck.AddDays((-1) * dateToCheck.Day + 1);
                        dateRangeEnd = dateRangeBegin.Add(duration);
                        break;

                    case FrequencyType.Quarterly:
                        int currentQuater = (dateToCheck.Date.Month - 1) / 3 + 1;
                        int daysInLastMonthOfQuarter = DateTime.DaysInMonth(dateToCheck.Year, 3 * currentQuater);
                        dateRangeBegin = new DateTime(dateToCheck.Year, 3 * currentQuater - 2, 1);
                        dateRangeEnd = new DateTime(dateToCheck.Year, 3 * currentQuater, daysInLastMonthOfQuarter);
                        break;

                    case FrequencyType.Annually:
                        dateRangeBegin = new DateTime(dateToCheck.Year, 1, 1);
                        dateRangeEnd = new DateTime(dateToCheck.Year, 12, 31);
                        break;
                }
                result[0] = dateRangeBegin.Date.ToString(format);
                result[1] = dateRangeEnd.Date.ToString(format);
            }
            catch (Exception ex)
            {
                result[0] = "";
                result[1] = ex.Message;
            }
            return result;
        }
        public enum FrequencyDateType
        {
            Today = 0, // Hôm nay
            ThisWeek = 1, // Tuần này
            ThisMonth = 2, // Tháng này
            ThisQuarter = 3, // Quý này
            ThisYear = 4, // Năm nay
            January = 5, // T1
            February = 6, // T2
            March = 7, // T3
            April = 8, // T4
            May = 9, // T5
            June = 10, // T6
            July = 11, // T7
            August = 12, // T8
            September = 13, // T9
            October = 14, // T10
            November = 15, // T11
            December = 16, // T12
            Q1 = 17, // Quý I
            Q2 = 18, // Quý II
            Q3 = 19, // Quý III
            Q4 = 20, // Quý IV
            LastWeek = 21, // Tuần trước
            LastMonth = 22, // Tháng trước
            LastQuarter = 23, // Quý trước
            LastYear = 24, // Năm trước
            Option = 25, // Tùy chọn
            AllTime = 26, // Toàn thời gian
        }
        public static string[] FrequencyDateTypeString()
        {
            return new string[] {
                "Hôm nay",
                "Tuần này",
                "Tháng này",
                "Quý này",
                "Năm nay",
                "Tháng 1",
                "Tháng 2",
                "Tháng 3",
                "Tháng 4",
                "Tháng 5",
                "Tháng 6",
                "Tháng 7",
                "Tháng 8",
                "Tháng 9",
                "Tháng 10",
                "Tháng 11",
                "Tháng 12",
                "Quý I",
                "Quý II",
                "Quý III",
                "Quý IV",
                "Tuần trước",
                "Tháng trước",
                "Quý trước",
                "Năm trước",
                "Tùy chọn",
                "Toàn thời gian"
            };
        }
        public static string[] GetRangeOfDate(FrequencyDateType frequency, DateTime dateToCheck, string format)
        {
            string[] result = new string[2];
            try
            {
                FrequencyType frequencyType = FrequencyType.Daily;
                switch (frequency)
                {
                    case FrequencyDateType.Today:
                        frequencyType = FrequencyType.Daily;
                        break;
                    case FrequencyDateType.ThisWeek:
                        frequencyType = FrequencyType.Weekly;
                        break;
                    case FrequencyDateType.ThisMonth:
                        frequencyType = FrequencyType.Monthly;
                        break;
                    case FrequencyDateType.ThisQuarter:
                        frequencyType = FrequencyType.Quarterly;
                        break;
                    case FrequencyDateType.ThisYear:
                        frequencyType = FrequencyType.Annually;
                        break;
                    case FrequencyDateType.January:
                        frequencyType = FrequencyType.Monthly;
                        dateToCheck = DateTime.Parse(dateToCheck.Year + "/01/01");
                        break;
                    case FrequencyDateType.February:
                        frequencyType = FrequencyType.Monthly;
                        dateToCheck = DateTime.Parse(dateToCheck.Year + "/02/01");
                        break;
                    case FrequencyDateType.March:
                        frequencyType = FrequencyType.Monthly;
                        dateToCheck = DateTime.Parse(dateToCheck.Year + "/03/01");
                        break;
                    case FrequencyDateType.April:
                        frequencyType = FrequencyType.Monthly;
                        dateToCheck = DateTime.Parse(dateToCheck.Year + "/04/01");
                        break;
                    case FrequencyDateType.May:
                        frequencyType = FrequencyType.Monthly;
                        dateToCheck = DateTime.Parse(dateToCheck.Year + "/05/01");
                        break;
                    case FrequencyDateType.June:
                        frequencyType = FrequencyType.Monthly;
                        dateToCheck = DateTime.Parse(dateToCheck.Year + "/06/01");
                        break;
                    case FrequencyDateType.July:
                        frequencyType = FrequencyType.Monthly;
                        dateToCheck = DateTime.Parse(dateToCheck.Year + "/07/01");
                        break;
                    case FrequencyDateType.August:
                        frequencyType = FrequencyType.Monthly;
                        dateToCheck = DateTime.Parse(dateToCheck.Year + "/08/01");
                        break;
                    case FrequencyDateType.September:
                        frequencyType = FrequencyType.Monthly;
                        dateToCheck = DateTime.Parse(dateToCheck.Year + "/09/01");
                        break;
                    case FrequencyDateType.October:
                        frequencyType = FrequencyType.Monthly;
                        dateToCheck = DateTime.Parse(dateToCheck.Year + "/10/01");
                        break;
                    case FrequencyDateType.November:
                        frequencyType = FrequencyType.Monthly;
                        dateToCheck = DateTime.Parse(dateToCheck.Year + "/11/01");
                        break;
                    case FrequencyDateType.December:
                        frequencyType = FrequencyType.Monthly;
                        dateToCheck = DateTime.Parse(dateToCheck.Year + "/12/01");
                        break;
                    case FrequencyDateType.Q1:
                        frequencyType = FrequencyType.Quarterly;
                        dateToCheck = DateTime.Parse(dateToCheck.Year + "/01/01");
                        break;
                    case FrequencyDateType.Q2:
                        frequencyType = FrequencyType.Quarterly;
                        dateToCheck = DateTime.Parse(dateToCheck.Year + "/04/01");
                        break;
                    case FrequencyDateType.Q3:
                        frequencyType = FrequencyType.Quarterly;
                        dateToCheck = DateTime.Parse(dateToCheck.Year + "/07/01");
                        break;
                    case FrequencyDateType.Q4:
                        frequencyType = FrequencyType.Quarterly;
                        dateToCheck = DateTime.Parse(dateToCheck.Year + "/10/01");
                        break;
                    case FrequencyDateType.LastWeek:
                        frequencyType = FrequencyType.Weekly;
                        dateToCheck = dateToCheck.AddDays(-7);
                        break;
                    case FrequencyDateType.LastMonth:
                        frequencyType = FrequencyType.Monthly;
                        dateToCheck = dateToCheck.AddMonths(-1);
                        break;
                    case FrequencyDateType.LastQuarter:
                        frequencyType = FrequencyType.Quarterly;
                        dateToCheck = dateToCheck.AddMonths(-3);
                        break;
                    case FrequencyDateType.LastYear:
                        frequencyType = FrequencyType.Annually;
                        dateToCheck = dateToCheck.AddYears(-1);
                        break;
                }
                result = GetRange(frequencyType, dateToCheck, format);
            }
            catch (Exception ex)
            {
                result[0] = "";
                result[1] = ex.Message;
            }
            return result;
        }
    }
}
