using System;
using GxHelper.TaskSchedul;
using GxHelper.FileBase;
using GxHelper.FileBase.LogHelper;

namespace Gx.Test.UnitTest.TaskSchedulTest
{
    public class Job : TaskSchedulBase
    {
        public override TriggerHelper trigger
        {
            get
            {
                return new TriggerHelper()
                    .WithCronSchedule("*/1 * * * * ?");
            }
        }
        public override void DoExecute()
        {
            LogHelper.Debug(DateTime.Now.ToString("HH:mm:ss"));
        }
    }
}
