using System;
using System.Text.RegularExpressions;

namespace GenericTesting
{
  public static class TimeZoneInfoHelpers
  {
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

    //public static T OffsetDateAddedChecker<T>(string dateString, Func<DateTime, DateTime> customMethodToRun)
    //{
    //    var date = Convert.ToDateTime(dateString);

    //  if (typeof(T) == typeof(DateTime))
    //  {
    //    return (T)(object)(Regex.IsMatch(dateString, @"Z|GMT|[+-][1-9]:[0-9]") ? date.ToUniversalTime() : customMethodToRun(date));
    //  }
        
    //  else if (typeof(T) == typeof(DateTimeOffset))
          
    //}

  public static DateTime OffsetDateAddedChecker(string dateString, Func<DateTime, DateTime> customMethodToRun)
  {
    var date = Convert.ToDateTime(dateString);

    return Regex.IsMatch(dateString, @"Z|GMT|[+-][1-9]:[0-9]") ? date.ToUniversalTime() : customMethodToRun(date);
  }

  }
}
