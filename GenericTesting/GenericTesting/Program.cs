using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using System.Data;
using System.Linq;
using System.Collections.ObjectModel;
using System.Web.Script.Serialization;
using System.Text;
using static GenericTesting.HackerRankChallenges.Algorithms;

namespace GenericTesting
{
  class Program
  {
    public int MyProperty { get; private set; }
    
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

    public static void ApiMock(string s)
    {
      Console.WriteLine($"I worked on {s}!");
    }
    
    public class POC
    {
      public int Id { get; set; }
      public string Desc { get; set; }
      public List<Order> Orders { get; set; }
    }

    public class Order
    {
      public int Id { get; set; }
      public string Desc { get; set; }
    }

    static List<POC> GetPOCOs()
    {
      return new List<POC>
      {
          new POC { Id = 1, Desc = "John"},
          new POC { Id = 2, Desc = "Jane" },
          new POC { Id = 3, Desc = "Joey" }
      };
    }

    static List<Order> GetOrders(int numberOfOrders)
    {
      var orders = new List<Order>();

      for (int i = 1; i <= numberOfOrders; i++)
      {
        orders.Add(new Order { Id = i, Desc = $"{i} Order" });
      }

      return orders;
    }

    static List<POC> GetPOCOsAndOrders()
    {
      return new List<POC>
      {
          new POC { Id = 1, Desc = "John", Orders = GetOrders(1)},
          new POC { Id = 2, Desc = "Jane", Orders = GetOrders(2) },
          new POC { Id = 3, Desc = "Joey" , Orders = GetOrders(3)}
      };
    }
    

    static void Main(string[] args)
    {
      

      Console.ReadLine();
    }
    
    private static POC SwitchLambdaExample()
    {
      var pocos = GetPOCOs();

      var item = pocos.FirstOrDefault(x => { switch (x.Id) { case 2: return true; default: return false; } });
      return item;
    }
  }
  
}
