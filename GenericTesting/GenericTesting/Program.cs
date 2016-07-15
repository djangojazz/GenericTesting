using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using System.Data;
using System.Linq;

namespace GenericTesting
{
  class Program
  {
    public int MyProperty { get; private set; }

    static List<POCO> GetPOCOs()
    {
      return new List<POCO>
      {
          new POCO { Id = 1, Name = "John", Description = "basic" },
          new POCO { Id = 2, Name = "Jane", Description = "" },
          new POCO { Id = 3, Name = "Joey", Description = "advanced" }
      };
    }
    
    public delegate void ProcessTimer(object sender, ElapsedEventArgs e);

    private static List<Timer> TimerList = new List<Timer>();
    public static void CreateGenericTimer(TimeSpan Duration, ProcessTimer Action)
    {
      Timer NewTimer = new Timer
      {
        Enabled = true,
        Interval = Duration.TotalMilliseconds,
        AutoReset = true
      };
      NewTimer.Elapsed += (sender, e) => Action.Invoke(sender, e);
      TimerList.Add(NewTimer);
    }


    //DISPOSE
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (disposing)
      {
        TimerList.ForEach((Timer x) => x.Dispose());
      }
    }

    private static void TimerGeneric(int duration, Func<Task> timerDuration)
    {
      var timer = new Timer(duration);
      timer.Elapsed += async (sender, e) => await timerDuration();
      timer.Enabled = true;
    }
    
    public class POC
    {
      public int Id { get; set; }
      public string Desc { get; set; }
    }
    
    public static List<T> GetSpecificFields<T>(DataTable dt, string columnName)
    {
      return dt.AsEnumerable().Select(x => (T)(object)x.Field<T>(columnName)).ToList();
    }

    public static void Test()
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

    static void Main(string[] args)
    {
      new Delegates.ComposableDelegates().ReturnData();

        //var sqltalker = new DataAccess.SQLTalker("VM-APC01D-CLK\\TEST", "distribution", "sqluser", "pa55word");

      //var results = sqltalker.Reader("EXEC sys.sp_replmonitorhelpsubscription 	@publication_type = 0", ",", true);

      Console.ReadLine();
    }

    private static POCO SwitchLambdaExample()
    {
      var pocos = GetPOCOs();

      var item = pocos.FirstOrDefault(x => { switch (x.Id) { case 2: return true; default: return false; } });
      return item;
    }
  }
  
}
