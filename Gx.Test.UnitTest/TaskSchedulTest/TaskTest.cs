using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GxHelper.TaskSchedul;
using GxHelper;

namespace Gx.Test.UnitTest.TaskSchedulTest
{
    [TestClass]
    public class TaskTest
    {
        [TestMethod]
        public void TestTaskSchedul()
        {
            TaskSchedulHelper.StartTask(new Job(), "任务1");
            DateTimeHelper.SleepForSeconds(10);
            TaskSchedulHelper.ShutdownTask("任务1");
        }
    }
}
