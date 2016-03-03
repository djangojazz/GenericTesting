using System;
using System.Collections.Generic;
using System.Net;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Timers;
using System.IO;
using System.Xml.Serialization;

namespace GenericTesting
{
  class Program
  {
    static List<POCO> GetPOCOs()
    {
      return new List<POCO>
      {
          new POCO { Id = 1, Name = "John", Description = "basic" },
          new POCO { Id = 2, Name = "Jane", Description = "more" },
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

    private static void TimerSetupWithRefresh(int refreshDuration)
    {
      Timer timer = new Timer(refreshDuration);
      timer.Elapsed += async (sender, e) => await Refresh();
      timer.Enabled = true;
    }

    private static async Task Refresh()
    {
      Console.WriteLine("Specific is: " + DateTime.Now);
    }

    public class Poc { public int Id { get; set; } public string Value { get; set; }}
    
    static void Main(string[] args)
    {
      var ls = new List<string> {"Know", "What", "I", "Mean"};

      ls.ForEach(x => Console.WriteLine(x));
      
      

      //TimerGeneric(1000, async () => { Console.WriteLine("Passed in Task is: " + DateTime.Now); });

      //Works just as expected and refreshes every second for the 'Refresh()' method.
      //TimerSetupWithRefresh(1000);

      //Below does not work yet I would expect a Task passed in via signature with near same method would behave the same.
      //TimerGeneric(1000, new Task(() => { Console.WriteLine("Passed in Task is: " + DateTime.Now); }));

      Console.ReadLine();
    }
  }
}
