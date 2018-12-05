using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GxHelper
{
    public static class DateTimeHelper
    {
        public static void SleepForHours(int hours)
        {
            SleepForMinutes(60 * hours);
        }
        public static void SleepForMinutes(int minutes)
        {
            SleepForSeconds(60 * minutes);
        }
        public static void SleepForSeconds(int seconds)
        {
            Sleep(1000 * seconds);
        }
        private static void Sleep(int time)
        {
            Thread.Sleep(time);
        }
        /// <summary>
        /// 本日开始时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime StartTimeForDay(this DateTime dt)
        {
            return Convert.ToDateTime(dt.ToShortDateString());
        }

        /// <summary>
        /// 本日结束时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime EndTimeForDay(this DateTime dt)
        {
            return dt.StartTimeForDay().AddDays(1).AddSeconds(-1);
        }

        /// <summary>
        /// 本周开始时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime StartTimeForWeek(this DateTime dt)
        {
            dt = Convert.ToDateTime(dt.ToShortDateString());
            return dt.AddDays(1 - (int)dt.DayOfWeek);
        }

        /// <summary>
        /// 本周结束时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime EndTimeForWeek(this DateTime dt)
        {
            return dt.StartTimeForWeek().AddDays(7).AddSeconds(-1);
        }

        /// <summary>
        /// 本月开始时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime StartTimeForMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }

        /// <summary>
        /// 本月结束时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime EndTimeForMonth(this DateTime dt)
        {
            return dt.StartTimeForMonth().AddMonths(1).AddSeconds(-1);
        }

        /// <summary>
        /// 本年开始时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime StartTimeForYear(this DateTime dt)
        {
            return new DateTime(dt.Year, 1, 1);
        }

        /// <summary>
        /// 本年结束时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime EndTimeForYear(this DateTime dt)
        {
            return dt.StartTimeForYear().AddYears(1).AddSeconds(-1);
        }
    }
}
