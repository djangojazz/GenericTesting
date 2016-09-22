using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using System.Data;
using System.Linq;
using System.Collections.ObjectModel;
using System.Web.Script.Serialization;
using System.Text;

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
    }

    static List<POC> GetPOCOs()
    {
      return new List<POC>
      {
          new POC { Id = 1, Desc = "John"},
          new POC { Id = 2, Desc = "Jane" },
          new POC { Id = 3, Desc = "\"Joey\"" }
      };
    }
    
    public class OtherPerson
    {
      public int PersonId { get; set; }
      public string PersonLongName { get; set; }
      public teOrder Order { get; set; }
    }

    static void Main(string[] args)
    {
      Func<decimal, bool> IsValid = (inputNumber) =>
      {
        return Decimal.Remainder((inputNumber / 3), 1) == 0 && Decimal.Remainder((inputNumber / 5), 1) == 0 ? true : false;
      };

      for (int i = 1; i <= 20; i++)
      {
        var items = new[] { "3", "5" };
        var combs = Enumerable.Repeat(items, i).CartesianProduct();
        decimal x = -1;
        
        foreach (var item in combs.ToList())
        {
          Decimal.TryParse(String.Join("", item), out x);
          if (IsValid(x)) break;
          else x = -1;  
        }
        
        Console.WriteLine($"{i} {x}");
      }

      Console.ReadLine();
    }
    
    private static void PlayingWithEntity()
    {
      using (var context = new TesterEntities())
      {
        //Say I just want to project a new object with a select starting from orders and then traversing up.  Not too hard
        var newObjects = context.teOrders.Where(order => order.OrderId == 1)
          //SelectMan will FLATTEN a list off of a parent or child in a one to many relationship
          .SelectMany(peopleInOrderOne => peopleInOrderOne.tePersons)
          .ToList()
          .Select(existingPerson => new OtherPerson
          {
            PersonId = existingPerson.PersonId,
            PersonLongName = $"{existingPerson.FirstName} {existingPerson.LastName}",
            Order = existingPerson.teOrder
          })
          .ToList();

        newObjects.ForEach(newPerson => Console.WriteLine($"{newPerson.PersonId} {newPerson.PersonLongName} {newPerson.Order.Description}"));

        // Just an action clause to repeat find items in my context, the important thing to note is that y extends teOrder which is another POCO inside my POCO
        Action<string, List<tePerson>> GetOrdersForPeople = (header, people) =>
        {
          Console.WriteLine(header);
          people.ForEach(person => Console.WriteLine($"{person.FirstName} {person.LastName} {person.teOrder.Description}"));
          Console.WriteLine();
        };

        //I want to look at a person and their orders.  I don't have to do multiple selects down, lazy loading by default gives me a child object off of EF
        GetOrdersForPeople("First Run", context.tePersons.ToList());


        //Say I want a new order for a set of persons in my list?
        var newOrder = new teOrder { Description = "Shoes" };
        context.teOrders.Add(newOrder);
        context.SaveChanges();

        //Now I want to add the new order
        context.tePersons.SingleOrDefault(person => person.PersonId == 1).teOrder = newOrder;
        context.SaveChanges();

        //I want to rexamine now
        GetOrdersForPeople("After changes", context.tePersons.ToList());

        //My newOrder is in memory and I can alter it like clay still and the database will know if I change the context
        newOrder.Description = "Athletic Shoes";
        context.SaveChanges();

        GetOrdersForPeople("After changes 2", context.tePersons.ToList());

        //Say I want to update a few people with new orders at the same time
        var peopleBesidesFirst = context.tePersons.Where(person => person.PersonId != 1).ToList();
        var firstPersonInList = context.tePersons.Where(person => person.PersonId == 1).ToList();

        var newOrders = new List<teOrder> {
          new teOrder { Description = "Hat", tePersons = peopleBesidesFirst },
          new teOrder { Description = "Tie", tePersons = firstPersonInList }
          };

        context.teOrders.AddRange(newOrders);
        context.SaveChanges();

        GetOrdersForPeople("After changes 3", context.tePersons.ToList());
      }
    }

    private static POC SwitchLambdaExample()
    {
      var pocos = GetPOCOs();

      var item = pocos.FirstOrDefault(x => { switch (x.Id) { case 2: return true; default: return false; } });
      return item;
    }
  }
  
}
