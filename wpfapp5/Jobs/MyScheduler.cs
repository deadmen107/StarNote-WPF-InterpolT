using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Jobs
{
    public class MyScheduler
    {
        public bool isVPRunning = false;


        private IScheduler Baslat()
        {
            Quartz.ISchedulerFactory schedFact = new StdSchedulerFactory();
            Quartz.IScheduler sched = schedFact.GetScheduler().GetAwaiter().GetResult();

            if (!sched.IsStarted)
                sched.Start();

            return sched;
        }
        public void GoreviTetikle()
        {
            Quartz.IScheduler sched = Baslat();
            Quartz.IJobDetail Gorev = JobBuilder.Create<ApiJobs>().WithIdentity("ApiJobs", null).Build();
            Quartz.ISimpleTrigger TriggerGorev = (ISimpleTrigger)TriggerBuilder.Create().WithIdentity("ApiJobs").StartAt(DateTime.UtcNow).WithSimpleSchedule(x => x.WithIntervalInMinutes(5).RepeatForever()).Build();
            sched.ScheduleJob(Gorev, TriggerGorev);
        }

    }
}
