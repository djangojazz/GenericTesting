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
      // Set up a test table
      var dt = new DataTable();
      DataRow row;

      var col1 = new DataColumn("Id", typeof(int));
      var col2 = new DataColumn("Desc", typeof(string));
      dt.Columns.AddRange(new DataColumn[] { col1, col2 });
      
      // give it some test data
      for (int i = 0; i < 3; i++)
      {
        row = dt.NewRow();
        row["Id"] = i;
        row["Desc"] = "item " + i.ToString();
        dt.Rows.Add(row);
      }

      // Test out the methods be aware this is very very brittle
      GetSpecificFields<int>(dt, "Id").ForEach(x => Console.WriteLine(x));
      GetSpecificFields<string>(dt, "Desc").ForEach(x => Console.WriteLine(x));
      
      Console.ReadLine();

      //var timezones = TimeZoneInfo.GetSystemTimeZones();
      //var pst = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
      //var est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

      //var dtString = "2016-03-20T01:00:00";

      //var dtPSTOff = pst.ConvertDateFromTimeZoneToUTCElseDefaultUTCNow
      //  DateTimeOffset.Parse(dtString);


      //Console.WriteLine(Environment.NewLine + dtOff);
    }

    static void Main(string[] args)
    {
      Test();
      
      //TimerGeneric(1000, async () => { Console.WriteLine("Passed in Task is: " + DateTime.Now); });

      //Works just as expected and refreshes every second for the 'Refresh()' method.
      //TimerSetupWithRefresh(1000);

      //Below does not work yet I would expect a Task passed in via signature with near same method would behave the same.
      //TimerGeneric(1000, new Task(() => { Console.WriteLine("Passed in Task is: " + DateTime.Now); }));

      Console.ReadLine();
    }
  }
}
