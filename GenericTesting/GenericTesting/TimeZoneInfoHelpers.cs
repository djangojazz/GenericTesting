using System;
using System.Text.RegularExpressions;

namespace GenericTesting
{
  public static class TimeZoneInfoHelpers
  {
    private static T ReturnDefaultOfType<T>()
    {
      return (typeof(T) == typeof(DateTimeOffset)) ? (T)(object)DateTimeOffset.UtcNow : (T)(object)DateTime.UtcNow;
    }

    public static T ConvertDateFromTimeZoneToUTCElseDefaultUTCNow<T>(this TimeZoneInfo timeZone, string dateString)
    {
      try
      {
        if (string.IsNullOrEmpty(dateString))
        {
          return ReturnDefaultOfType<T>();
        }

        var dt = OffsetDateAddedChecker(dateString, x => TimeZoneInfo.ConvertTimeToUtc(x, timeZone));
        var dtOffset = new DateTimeOffset(dt, new TimeSpan());

        return (typeof(T) == typeof(DateTimeOffset)) ? (T)(object)dtOffset : (T)(object)dt;
      }
      catch(Exception ex)
      {
        throw ex;
      }
    }
    
    public static T ConvertDateToTimeZoneFromUTCElseDefaultUTCNow<T>(this TimeZoneInfo timeZone, string dateString)
    {
        try
        {
          if (string.IsNullOrEmpty(dateString))
          {
            return ReturnDefaultOfType<T>();
          }

          var dt = OffsetDateAddedChecker(dateString, x => TimeZoneInfo.ConvertTimeFromUtc(x, timeZone));
          var offset = timeZone.GetUtcOffset(dt);
          var dtOffset = new DateTimeOffset(dt, offset);

          return (typeof(T) == typeof(DateTimeOffset)) ? (T)(object)dtOffset : (T)(object)dt;
        }
        catch(Exception ex)
        {
          throw ex;
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

    public static T OffsetDateAddedChecker<T>(string dateString, Func<DateTime, T> customMethodToRun)
    {
      var date = DateTime.Parse(dateString);
      var dateOffset = DateTimeOffset.Parse(dateString);

      if (typeof(T) == typeof(DateTime))
      {
        return Regex.IsMatch(dateString, @"Z|GMT|[+-][1-9]:[0-9]") ? (T)(object)date.ToUniversalTime() : (T)(object)customMethodToRun(date);
      }
      else if (typeof(T) == typeof(DateTimeOffset))
      {
        return Regex.IsMatch(dateString, @"Z|GMT|[+-][1-9]:[0-9]") ? (T)(object)dateOffset.ToUniversalTime() : (T)(object)customMethodToRun(date);
      }
      else
        return (T)(object)(date.ToUniversalTime());
    }
  }
}
