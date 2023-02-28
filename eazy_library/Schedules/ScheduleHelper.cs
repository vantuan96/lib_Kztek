using System;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace eazy_library.Schedules
{
    public class ScheduleHelper
    {
        static IScheduler scheduler;

        public async static Task Start()
        {
            scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();
        }

        public async static Task Stop()
        {
            if (scheduler.IsStarted)
            {
                await scheduler.Shutdown();
            }
        }

        public async static Task<bool> checkScheduleStart()
        {
            scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            return scheduler.IsStarted;
        }

        public async static Task<DateTimeOffset> Register<T>(ScheduleModel schedule) where T : IJob
        {
            var isStart = await checkScheduleStart();
            if (isStart == false)
            {
                await Start();
            }

            var job = JobBuilder.Create<T>()
                .WithIdentity(schedule.Name, schedule.Group)
                .WithDescription(schedule.Description)
                .Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity(schedule.Name, schedule.Group)
                .ForJob(schedule.Name, schedule.Group)
                .WithCronSchedule(schedule.cronExpression)
                .Build();

            return await scheduler.ScheduleJob(job, trigger);
        }
    }
}