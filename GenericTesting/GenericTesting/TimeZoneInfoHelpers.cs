using System;
using System.Text.RegularExpressions;

namespace GenericTesting
{
  public static class TimeZoneInfoHelpers
  {
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

    private static T OffsetDateAddedChecker<T>(string dateString, Func<DateTime, T> customMethodToRun)
    {
      var date = DateTime.Parse(dateString);
      var dateOffset = DateTimeOffset.Parse(dateString);

      if (typeof(T) == typeof(DateTime))
        return Regex.IsMatch(dateString, @"Z|GMT|[+-][1-9]:[0-9]") ? (T)(object)date.ToUniversalTime() : (T)(object)customMethodToRun(date);
      else if (typeof(T) == typeof(DateTimeOffset))
        return Regex.IsMatch(dateString, @"Z|GMT|[+-][1-9]:[0-9]") ? (T)(object)dateOffset.ToUniversalTime() : (T)(object)customMethodToRun(date);
      else
        return (T)(object)(date.ToUniversalTime());
    }

    private static T ReturnDefaultOfType<T>()
    {
      return (typeof(T) == typeof(DateTimeOffset)) ? (T)(object)DateTimeOffset.UtcNow : (T)(object)DateTime.UtcNow;
    }

    public static void TestTimeZoneStuff()
    {
      var timezones = TimeZoneInfo.GetSystemTimeZones();
      var utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
      var pst = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
      var est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

      var dtString = "2016-03-13T01:00:00";
      var dtString2 = "2016-03-14T01:00:00";

      var dtUTC = utc.ConvertDateToTimeZoneFromUTCElseDefaultUTCNow<DateTimeOffset>(dtString);
      var dtPST = pst.ConvertDateToTimeZoneFromUTCElseDefaultUTCNow<DateTimeOffset>(dtString);
      var dtEST = est.ConvertDateToTimeZoneFromUTCElseDefaultUTCNow<DateTimeOffset>(dtString);
      var dtUTC2 = utc.ConvertDateToTimeZoneFromUTCElseDefaultUTCNow<DateTimeOffset>(dtString2);
      var dtPST2 = pst.ConvertDateToTimeZoneFromUTCElseDefaultUTCNow<DateTimeOffset>(dtString2);
      var dtEST2 = est.ConvertDateToTimeZoneFromUTCElseDefaultUTCNow<DateTimeOffset>(dtString2);
      var nl = Environment.NewLine;

      Console.WriteLine($"utc: {dtUTC}{nl}est:{dtEST}{nl}pst:{dtPST}");
      Console.WriteLine($"utc: {dtUTC2}{nl}est:{dtEST2}{nl}pst:{dtPST2}");
    }
  }
}
