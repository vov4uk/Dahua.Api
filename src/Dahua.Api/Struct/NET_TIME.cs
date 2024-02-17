using System;
using System.Runtime.InteropServices;

namespace Dahua.Api.Struct
{
    /// <summary>
    ///  NET_TIME
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NET_TIME
    {

        /// <summary>
        /// The dw year
        /// </summary>
        public int dwYear;

        /// <summary>
        /// The dw month
        /// </summary>
        public int dwMonth;

        /// <summary>
        /// The dw day
        /// </summary>
        public int dwDay;

        /// <summary>
        /// The dw hour
        /// </summary>
        public int dwHour;

        /// <summary>
        /// The dw minute
        /// </summary>
        public int dwMinute;

        /// <summary>
        /// The dw second
        /// </summary>
        public int dwSecond;

        /// <summary>
        /// Converts to datetime.
        /// </summary>
        /// <returns></returns>
        public readonly DateTime ToDateTime()
        {
            try
            {
                return new DateTime(dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond);
            }
            catch
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// From the date time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static NET_TIME FromDateTime(DateTime dateTime)
        {
            try
            {
                NET_TIME net_time = new NET_TIME
                {
                    dwYear = dateTime.Year,
                    dwMonth = dateTime.Month,
                    dwDay = dateTime.Day,
                    dwHour = dateTime.Hour,
                    dwMinute = dateTime.Minute,
                    dwSecond = dateTime.Second
                };
                return net_time;
            }
            catch
            {
                return new NET_TIME();
            }
        }
    }
}
