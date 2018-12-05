using Quartz;
using Quartz.Collection;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GxHelper.TaskSchedul
{
    public class TaskSchedulHelper
    {
        private static ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
        private static IScheduler scheduler = schedulerFactory.GetScheduler();
        public static void StartTask(TaskSchedulBase task, string jobName)
        {
            scheduler.Start();
            IJobDetail job = task.job
                .WithIdentity(StringHelper.GetGuid(), jobName)
                .Build();
            ITrigger trigger = task.trigger
                .WithIdentity(StringHelper.GetGuid(), jobName)
                .Build();
            scheduler.ScheduleJob(job, trigger);
        }
        public static void StartTask(Dictionary<TaskSchedulBase, string> tasks)
        {
            tasks.ToList().ForEach(task =>
            {
                StartTask(task.Key, task.Value);
            });
        }
        public static void ShutdownTask(string jobName)
        {
            GroupMatcher<TriggerKey> groupTriggerKey = GroupMatcher<TriggerKey>.GroupEquals(jobName);
            scheduler.PauseTriggers(groupTriggerKey);

            GroupMatcher<JobKey> groupJobKey = GroupMatcher<JobKey>.GroupEquals(jobName);
            scheduler.PauseJobs(groupJobKey);

            scheduler.DeleteJobs(scheduler.GetJobKeys(groupJobKey).ToList());
        }
    }
}
