using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace GxHelper.TaskSchedul
{
    public abstract class TaskSchedulBase : IJob
    {
        public JobDataMap jobDate = new JobDataMap();
        public abstract TriggerHelper trigger { get; }
        public JobBuilder job
        {
            get
            {
                return JobBuilder.Create(this.GetType()).SetJobData(jobDate);
            }
        }
        public void Execute(IJobExecutionContext context)
        {
            DoExecute();
        }
        public abstract void DoExecute();
    }
}
