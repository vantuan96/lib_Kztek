using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eazy_library.Cores.Models;
using eazy_library.Helpers;
using eazy_library.Models;
using Quartz;

namespace eazy_library.Schedules.Jobs
{
    public class TIME_TimeAttendanceJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var time = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy"); //Ngày hôm trước

            //
            var url = string.Format("{0}{1}", await AppSettingHelper.GetStringFromAppSetting("Host:Main"), "api/test/auto?date=" + time);

            //
            _ = await ApiHelper.HttpGet(url, "");
        }
    }
}