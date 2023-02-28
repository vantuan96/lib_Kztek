using System;
using System.Text;
using System.Threading.Tasks;
using eazy_library.Cores.Models;
using eazy_library.Models;

namespace eazy_library.Helpers
{
    public class CheckTimeHelper
    {
        public static bool IsInWorkHour(DateTime utc)
        {
            //Lấy cấu hình từ db
            var config = GetConfig();

            //
            var timeIn2 = Convert.ToDateTime(config.HourEnd);

            //Ngoài giờ hành chính
            if (utc.Hour == timeIn2.Hour && utc.Minute > 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Kiểm tra đi làm đúng giờ => phạt
        /// </summary>
        /// <param name="utc"></param>
        /// <returns></returns>
        public static PenaltyModel CheckOnTime(DateTime utc)
        {
            //Lấy cấu hình từ db
            var config = GetConfig();

            //
            var checkin = utc.ToLocalTime();
            var now = DateTime.Now;

            var checktime = Convert.ToDateTime(now.ToString(string.Format("{0} {1}", checkin.ToString("dd/MM/yyyy"), config.HourStart)));

            var k = (checkin - checktime).TotalMinutes;

            if (k >= 15)
            {
                return new PenaltyModel()
                {
                    money = config.PenaltyBeyond15,
                    TotalMinutes = k
                };
            }
            else if (0 < k && k < 15)
            {
                return new PenaltyModel()
                {
                    money = config.PenaltyUnder15,
                    TotalMinutes = k
                };
            }
            else
            {
                return new PenaltyModel()
                {
                    money = 0,
                    TotalMinutes = 0
                };
            }
        }

        /// <summary>
        /// Kiểm tra làm thêm có check đúng
        /// </summary>
        /// <param name="utc"></param>
        /// <returns></returns>
        public static MessageReport CheckValidTimeInOvertime(DateTime utc)
        {
            //Lấy cấu hình từ db
            var config = GetConfig();

            //
            var timeIn1 = Convert.ToDateTime(config.HourStart);
            var timeIn2 = Convert.ToDateTime(config.HourEnd);

            var result = new MessageReport(true, "Hợp lệ");

            var checkin = utc.ToLocalTime();

            //Kiểm tra trogn giờ hành chính 8:00 => 17:00
            if (checkin >= timeIn1 && checkin <= timeIn2)
            {
                result = new MessageReport(false, "Không thể check trong giờ hành chính");
                return result;
            }

            return result;
        }

        /// <summary>
        /// Tính số giờ làm việc khi ra
        /// </summary>
        /// <param name="datetimein"></param>
        /// <param name="datetimeout"></param>
        /// <returns></returns>
        public static double TotalHours(DateTime datetimein, DateTime datetimeout)
        {
            var result = (datetimeout - datetimein).TotalHours;

            return result;
        }

        /// <summary>
        /// Tính ngày công
        /// </summary>
        /// <param name="totalhours"></param>
        /// <returns></returns>
        public static double TotalDay(double totalhours)
        {
            //Lấy cấu hình từ db
            var config = GetConfig();

            //
            var timeIn1 = Convert.ToDateTime(config.HourStart);
            var timeIn2 = Convert.ToDateTime(config.HourEnd);

            var totalHour = timeIn2.Hour - timeIn1.Hour - config.Rest;

            var result = totalhours / totalHour;

            return result;
        }

        /// <summary>
        /// Tính ngày công + giờ nghỉ trưa (1 tiếng)
        /// </summary>
        /// <param name="totalhours"></param>
        /// <returns></returns>
        public static double TotalDayIncludeRest(double totalhours)
        {
            //Lấy cấu hình từ db
            var config = GetConfig();

            //
            var timeIn1 = Convert.ToDateTime(config.HourStart);
            var timeIn2 = Convert.ToDateTime(config.HourEnd);

            var totalHour = timeIn2.Hour - timeIn1.Hour;

            var result = totalhours / totalHour;

            return result;
        }

        /// <summary>
        /// Cập nhật Summary
        /// </summary>
        /// <param name="accountid">Id tài khoản</param>
        /// <param name="time">thời gian checkin || checkout</param>
        /// <param name="field">1 - Cập nhật penalty, 2 - Cập nhật labor day, 3 - Cập nhật overtime, 4 - Cập nhật dayoff</param>
        /// <param name="newvalue"></param>
        /// <param name="newval"></param>
        /// <returns></returns>
        public static async Task<MessageReport> AutoEditMonthSummary(string accountid, DateTime time, string field = "", double newvalue = 0, decimal newval = 0)
        {
            var result = new MessageReport(false, "error");

            try
            {
                //Lấy thời gian
                var month = time.Month;
                var year = time.Year;

                result = await UpdateFieldSummary(accountid, month, year, field, newvalue, newval);
            }
            catch (System.Exception ex)
            {
                result = new MessageReport(false, ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Cập nhật Summary
        /// </summary>
        /// <param name="accountid">Tài khoản</param>
        /// <param name="month">Tháng</param>
        /// <param name="year">Năm</param>
        /// <param name="field">1 - Cập nhật penalty, 2 - Cập nhật labor day, 3 - Cập nhật overtime, 4 - Cập nhật dayoff</param>
        /// <param name="newvalue"></param>
        /// <param name="newval"></param>
        /// <returns></returns>
        public static async Task<MessageReport> AutoEditMonthSummary(string accountid, int month, int year, string field = "", double newvalue = 0, decimal newval = 0)
        {
            var result = new MessageReport(false, "error");

            try
            {
                result = await UpdateFieldSummary(accountid, month, year, field, newvalue, newval);
            }
            catch (System.Exception ex)
            {
                result = new MessageReport(false, ex.Message);
            }

            return result;
        }

        private static async Task<MessageReport> UpdateFieldSummary(string accountid, int month, int year, string field = "", double newvalue = 0, decimal newval = 0)
        {
            //Conmection
            var connect = await AppSettingHelper.GetStringFromAppSetting("ConnectionStrings:DefaultConnection");

            var result = new MessageReport(false, "error");

            try
            {
                var t = DateTime.Now;

                //Lấy bản ghi
                var command = new StringBuilder();
                command.AppendLine(string.Format("SELECT * FROM TIME_EmployeeMonthSummary WHERE AccountId = '{0}' AND Month = {1} AND Year = {2}", accountid, month, year));

                //Id nếu chưa có
                var objSummary = SqlHelper.ExcuteCommandToModel<TIME_EmployeeMonthSummaryModel>(connect, command.ToString());
                if (objSummary == null)
                {
                    objSummary = new TIME_EmployeeMonthSummaryModel()
                    {
                        Id = Guid.NewGuid().ToString(),
                        AccountId = accountid,

                        Month = month,
                        Year = year,
                        TotalDayOff = 0,
                        TotalLaborDay = 0,
                        TotalOvertime = 0,
                        TotalPenalty = 0,

                        DateCreated = t,
                        DateUpdated = t,
                    };

                    command.Clear();
                    command.AppendLine(string.Format("INSERT INTO dbo.[TIME_EmployeeMonthSummary] (Id, AccountId, Year, Month, TotalLaborDay, TotalOvertime, TotalDayOff, TotalPenalty, DateCreated, DateUpdated) VALUES ('{0}', '{1}', {2}, {3}, 0, 0, 0, 0, '{4}', '{5}')", objSummary.Id, objSummary.AccountId, objSummary.Year, objSummary.Month, objSummary.DateCreated.ToString("yyyy/MM/dd HH:mm:ss"), objSummary.DateUpdated.ToString("yyyy/MM/dd HH:mm:ss")));

                    result = SqlHelper.ExcuteCommandToMesageReport(connect, command.ToString());
                }

                //Format update
                command.Clear();
                var updateCommand = "UPDATE dbo.[TIME_EmployeeMonthSummary] SET {1} = {2}, DateUpdated='{3}' WHERE Id = '{0}'";

                //Cập nhật
                switch (field)
                {
                    case "1":

                        objSummary.TotalPenalty = objSummary.TotalPenalty + newval;

                        command.AppendLine(string.Format(updateCommand, objSummary.Id, "TotalPenalty", objSummary.TotalPenalty.ToString().Replace(",", "."), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));

                        result = SqlHelper.ExcuteCommandToMesageReport(connect, command.ToString());

                        break;

                    case "2":

                        objSummary.TotalLaborDay = objSummary.TotalLaborDay + newvalue;

                        command.AppendLine(string.Format(updateCommand, objSummary.Id, "TotalLaborDay", objSummary.TotalLaborDay.ToString().Replace(",", "."), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));

                        result = SqlHelper.ExcuteCommandToMesageReport(connect, command.ToString());

                        break;

                    case "3":

                        objSummary.TotalOvertime = objSummary.TotalOvertime + newvalue;

                        command.AppendLine(string.Format(updateCommand, objSummary.Id, "TotalOvertime", objSummary.TotalOvertime.ToString().Replace(",", "."), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));

                        result = SqlHelper.ExcuteCommandToMesageReport(connect, command.ToString());

                        break;

                    case "4":

                        objSummary.TotalDayOff = objSummary.TotalDayOff + newvalue;

                        command.AppendLine(string.Format(updateCommand, objSummary.Id, "TotalDayOff", objSummary.TotalDayOff.ToString().Replace(",", "."), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));

                        result = SqlHelper.ExcuteCommandToMesageReport(connect, command.ToString());
                        if (result.isSuccess)
                        {
                            //Cập nhật trong năm
                            command.Clear();
                            command.AppendLine(string.Format("SELECT * FROM HR_EmployeeDayOffTracking WHERE AccountId = '{0}' AND Year = {1}", accountid, year));

                            var objYearSummary = SqlHelper.ExcuteCommandToModel<HR_EmployeeDayOffTrackingModel>(connect, command.ToString());

                            if (objYearSummary == null)
                            {   
                                var time = DateTime.Now;

                                command.Clear();
                                command.AppendLine("INSERT INTO dbo.[HR_EmployeeDayOffTracking] (Id, AccountId, Year, TotalDayOff, DateCreated, DateUpdated) VALUES (");

                                command.AppendLine(string.Format("'{0}'", Guid.NewGuid().ToString()));
                                command.AppendLine(string.Format(", '{0}'", accountid));
                                command.AppendLine(string.Format(", {0}", year));

                                command.AppendLine(string.Format(", {0}", newvalue.ToString().Replace(",", ".")));

                                command.AppendLine(string.Format(", '{0}'", time.ToString("yyyy/MM/dd HH:mm:ss")));
                                command.AppendLine(string.Format(", '{0}'", time.ToString("yyyy/MM/dd HH:mm:ss")));

                                command.AppendLine(")");

                                result = SqlHelper.ExcuteCommandToMesageReport(connect, command.ToString());
                            }
                            else
                            {
                                objYearSummary.TotalDayOff = objYearSummary.TotalDayOff + newvalue;

                                command.Clear();
                                command.AppendLine(string.Format("UPDATE dbo.[HR_EmployeeDayOffTracking] SET"));
                                command.AppendLine(string.Format("TotalDayOff = {0}", objYearSummary.TotalDayOff.ToString().Replace(",", ".")));
                                command.AppendLine(string.Format("WHERE Id = '{0}'", objYearSummary.Id));

                                result = SqlHelper.ExcuteCommandToMesageReport(connect, command.ToString());
                            }
                        }


                        break;

                    default:

                        result = new MessageReport(false, "Chưa có trường cập nhật");

                        break;
                }
            }
            catch (System.Exception ex)
            {
                result = new MessageReport(false, ex.Message);
            }

            return result;
        }

        public static TimeSpan BusinessTimeDelta(DateTime start, DateTime stop)
        {
            if (start == stop)
                return TimeSpan.Zero;

            if (start > stop)
            {
                DateTime temp = start;
                start = stop;
                stop = temp;
            }

            // First we are going to truncate these DateTimes so that they are within the business day.

            // How much time from the beginning til the end of the day?
            DateTime startFloor = StartOfBusiness(start);
            DateTime startCeil = CloseOfBusiness(start);
            if (start < startFloor) start = startFloor;
            if (start > startCeil) start = startCeil;

            TimeSpan firstDayTime = startCeil - start;
            bool workday = true; // Saves doublechecking later
            if (!IsWorkday(start))
            {
                workday = false;
                firstDayTime = TimeSpan.Zero;
            }

            // How much time from the start of the last day til the end?
            DateTime stopFloor = StartOfBusiness(stop);
            DateTime stopCeil = CloseOfBusiness(stop);
            if (stop < stopFloor) stop = stopFloor;
            if (stop > stopCeil) stop = stopCeil;

            TimeSpan lastDayTime = stop - stopFloor;
            if (!IsWorkday(stop))
                lastDayTime = TimeSpan.Zero;

            // At this point all dates are snipped to within business hours.

            if (start.Date == stop.Date)
            {
                if (!workday) // Precomputed value from earlier
                    return TimeSpan.Zero;

                return stop - start;
            }

            // At this point we know they occur on different dates, so we can use
            // the offset from SOB and COB.

            TimeSpan timeInBetween = TimeSpan.Zero;
            TimeSpan hoursInAWorkday = (startCeil - startFloor);

            // I tried cool math stuff instead of a for-loop, but that leaves no clean way to count holidays.
            for (DateTime itr = startFloor.AddDays(1); itr < stopFloor; itr = itr.AddDays(1))
            {
                if (!IsWorkday(itr))
                    continue;

                // Otherwise, it's a workday!
                timeInBetween += hoursInAWorkday;
            }

            return firstDayTime + lastDayTime + timeInBetween;
        }

        public static bool IsWorkday(DateTime date)
        {
            // Weekend
            if (date.DayOfWeek == DayOfWeek.Sunday)
                return false;

            // Could add holiday logic here.

            return true;
        }

        public static DateTime StartOfBusiness(DateTime date)
        {
            //Lấy cấu hình từ db
            var config = GetConfig();
            //
            var time = Convert.ToDateTime(config.HourStart);

            return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
        }

        public static DateTime CloseOfBusiness(DateTime date)
        {
            //Lấy cấu hình từ db
            var config = GetConfig();
            //
            var time = Convert.ToDateTime(config.HourEnd);

            return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
        }

        public static HR_ConfigModel GetConfig()
        {
            //Connection
            var connect = AppSettingHelper.GetStringFromAppSetting("ConnectionStrings:DefaultConnection").Result;

            var query = "SELECT HourStart, HourEnd, PenaltyUnder15, PenaltyBeyond15, Rest FROM HR_Config";

            var model = SqlHelper.ExcuteCommandToModel<HR_ConfigModel>(connect, query);

            return model;
        }
    }
}