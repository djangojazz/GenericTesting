using System;
using System.Text.RegularExpressions;

namespace GenericTesting
{
    public static class TimeZoneInfoHelpers
    {
        /// <summary>
        /// Gets the Date listed at the Timezone specified TO UTC or bombs out with an exception.
        /// </summary>
        /// <param name="timeZoneName"></param>
        /// <param name="dateToConvert"></param>
        /// <returns>Returns Date that would be UTC from a target location timeZone</returns>
        public static DateTime ConvertDateFromTimeZoneToUTCElseDefaultUTCNow(this TimeZoneInfo timeZone, string dateString)
        {
            try
            {
                if (string.IsNullOrEmpty(dateString))
                {
                    return DateTime.UtcNow;
                }

                return OffsetDateAddedChecker(dateString, x => TimeZoneInfo.ConvertTimeToUtc(x, timeZone));

            }
            catch
            {
                return DateTime.UtcNow;
            }
        }

        /// <summary>
        /// Gets the Date listed at the Timezone specified FROM UTC or bombs out with an exception.
        /// </summary>
        /// <param name="timeZoneName"></param>
        /// <param name="dateToConvert"></param>
        /// <returns>Returns Date that would be local Timezone from a target UTC</returns>
        public static DateTime ConvertDateToTimeZoneFromUTCElseDefaultUTCNow(this TimeZoneInfo timeZone, string dateString)
        {
            try
            {
                if (string.IsNullOrEmpty(dateString))
                {
                    return DateTime.UtcNow;
                }

                return OffsetDateAddedChecker(dateString, x => TimeZoneInfo.ConvertTimeFromUtc(x, timeZone));
            }
            catch
            {
                return DateTime.UtcNow;
            }
        }


        /// <summary>
        /// Gets the Date listed at the Timezone specified TO UTC or bombs out with an exception.
        /// </summary>
        /// <param name="timeZoneName"></param>
        /// <param name="dateToConvert"></param>
        /// <returns>Returns Date that would be UTC from a target location timeZone</returns>
        public static DateTime ConvertDateFromTimeZoneToUTCElseDefaultUTCNow(this TimeZoneInfo timeZone, DateTime date)
        {
            try
            {
                var outDate = DateTime.SpecifyKind(date, DateTimeKind.Unspecified);
                return TimeZoneInfo.ConvertTimeToUtc(outDate, timeZone);
            }
            catch
            {
                return DateTime.UtcNow;
            }
        }

        /// <summary>
        /// Gets the Date listed at the Timezone specified FROM UTC or bombs out with an exception.
        /// </summary>
        /// <param name="timeZoneName"></param>
        /// <param name="dateToConvert"></param>
        /// <returns>Returns Date that would be local Timezone from a target UTC</returns>
        public static DateTime ConvertDateToTimeZoneFromUTCElseDefaultUTCNow(this TimeZoneInfo timeZone, DateTime date)
        {
            try
            {
                var outDate = DateTime.SpecifyKind(date, DateTimeKind.Unspecified);
                return TimeZoneInfo.ConvertTimeFromUtc(outDate, timeZone);
            }
            catch
            {
                return DateTime.UtcNow;
            }
        }

        public static DateTime OffsetDateAddedChecker(string dateString, Func<DateTime, DateTime> customMethodToRun)
        {
            var date = Convert.ToDateTime(dateString);

            return Regex.IsMatch(dateString, @"Z|GMT|[+-][1-9]:[0-9]") ? date.ToUniversalTime() : customMethodToRun(date);
        }

    }
}
