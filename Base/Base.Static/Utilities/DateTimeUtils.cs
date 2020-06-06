using System;
using System.Globalization;

namespace Base.Static.Utilities
{
    public static class DateTimeUtils
    {
        public static DateTime StartOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        public static DateTime EndOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        public static string GetTimeAgoDisplay(DateTime date)
        {
            var now = DateTime.Now;
            if (DateTime.Compare(now, date) >= 0)
            {
                var s = DateTime.Now.Subtract(date);
                var w = DateTime.Now.StartOfWeek(DayOfWeek.Monday).Subtract(date);

                var numberDays = (now - date).Days;

                var dayDiff = (int) s.TotalDays;
                var weekDiff = DateTime.Now.DayOfWeek == DayOfWeek.Monday ? (int) w.TotalDays + 7 : (int) w.TotalDays;

                var secDiff = (int) s.TotalSeconds;

                if (dayDiff == 0)
                {
                    if (secDiff < 60) return "vừa xong";
                    if (secDiff < 120) return "1 phút trước";
                    if (secDiff < 3600) return string.Format("{0} phút trước", Math.Floor((double) secDiff / 60));
                    if (secDiff < 7200) return "1 giờ trước";
                    if (secDiff < 86400) return string.Format("{0} giờ trước", Math.Floor((double) secDiff / 3600));
                }

                if (numberDays == 1) return "Hôm qua lúc " + date.ToString("HH:mm");
                if (dayDiff > 1 && weekDiff < 7)
                {
                    var dateOfWeek = string.Empty;
                    switch (date.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            dateOfWeek = "Thứ hai";
                            break;
                        case DayOfWeek.Tuesday:
                            dateOfWeek = "Thứ ba";
                            break;
                        case DayOfWeek.Wednesday:
                            dateOfWeek = "Thứ tư";
                            break;
                        case DayOfWeek.Thursday:
                            dateOfWeek = "Thứ năm";
                            break;
                        case DayOfWeek.Friday:
                            dateOfWeek = "Thứ sáu";
                            break;
                        case DayOfWeek.Saturday:
                            dateOfWeek = "Thứ bảy";
                            break;
                        case DayOfWeek.Sunday:
                            dateOfWeek = "Chủ nhật";
                            break;
                    }

                    return string.Format("{0} lúc {1}", dateOfWeek, date.ToString("HH:mm"));
                }

                //if (dayDiff < 7)
                //{
                //    return string.Format("{0} ngày trước", dayDiff);
                //}
                if (dayDiff < 31)
                    //return string.Format("{0} tuần trước", Math.Ceiling((double)dayDiff / 7));
                    return string.Format("{0} ngày trước", dayDiff);
                if (dayDiff < 365) return string.Format("{0} tháng trước", Math.Ceiling((double) dayDiff / 30));
                if (dayDiff >= 365)
                    return string.Format("{0} {1}:{2}", date.ToString("dd/MM/yyyy"),
                        date.Hour < 10 ? "0" + date.Hour : date.Hour + "",
                        date.Minute < 10 ? "0" + date.Minute : date.Minute + "");
                return string.Empty;
            }

            return string.Empty;
        }

        

        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            var diff = startOfWeek - dt.DayOfWeek;
            if (diff < 0) diff += 7;
            return dt.AddDays(diff).Date;
        }


        public static DateTime ConvertStringToDateTime(string value, string format)
        {
            return DateTime.ParseExact(value, format, CultureInfo.InvariantCulture);
        }


        /// <summary>
        ///     Return double, > 0 then dateTo > dateFrom
        /// </summary>
        /// <pre>instant: d = Date, h = Hour, m = Minute, s = Second</pre>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="instant"></param>
        /// <returns></returns>
        public static double DateDiff(DateTime dateFrom, DateTime dateTo, string instant)
        {
            var span = dateTo - dateFrom;
            var num = 0.0;
            var str = instant.ToLower();
            if (str == null) return num;
            if (str != "d")
            {
                if (str != "h")
                {
                    if (str == "m") return span.TotalMinutes;
                    if (str != "s") return num;
                    return span.TotalSeconds;
                }
            }
            else
            {
                return span.TotalDays;
            }

            return span.TotalHours;
        }

        public static long DateTimeToUnixTime(DateTime dateTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var span = dateTime - epoch.ToLocalTime();
            return (long) (span.TotalSeconds * 1000.0 + DateTime.UtcNow.Millisecond);
        }

        public static long DateTimeToUnixTimeDaily(DateTime dateTime)
        {
            dateTime = DateTime.Parse(dateTime.ToString("MM/dd/yyyy 00:00:00"));
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var span = dateTime.Date - epoch.ToLocalTime();
            return (long) (span.TotalSeconds * 1000.0);
        }

        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp / 1000.0).ToLocalTime();
            return dtDateTime;
        }

        public static long DateTimeToSpanHourly(DateTime dateTime)
        {
            dateTime = DateTime.Parse(dateTime.ToString("MM/dd/yyyy HH:00:00"));
            var time = new DateTime(0x7b2, 1, 1, 0, 0, 0, 0);
            var span = dateTime - time.ToLocalTime();
            return (long) (span.TotalSeconds * 1000.0);
        }
        public static string DateTimeToISO8601Text(DateTime dateTime)
        {
            return dateTime.ToString("o");
        }
    }
}