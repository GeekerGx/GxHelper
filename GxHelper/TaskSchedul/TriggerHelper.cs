using Quartz;
using System;

namespace GxHelper.TaskSchedul
{
    public class TriggerHelper
    {
        private TriggerBuilder trigger;
        public TriggerHelper()
        {
            trigger = TriggerBuilder.Create();
        }
        internal TriggerHelper WithIdentity(string name, string group)
        {
            trigger.WithIdentity(name, group);
            return this;
        }
        public TriggerHelper WithCronSchedule(string cronExpression)
        {
            trigger.WithCronSchedule(cronExpression);
            return this;
        }
        public TriggerHelper StartAt(DateTimeOffset startTimeUtc)
        {
            trigger.StartAt(startTimeUtc);
            return this;
        }
        public TriggerHelper EndAt(DateTimeOffset endTimeUtc)
        {
            trigger.EndAt(endTimeUtc);
            return this;
        }
        internal ITrigger Build()
        {
            return trigger.Build();
        }
    }
}
