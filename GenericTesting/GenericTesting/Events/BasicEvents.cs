using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting.Events
{
  public class BasicEvents
  {
    public delegate void myEventHandler(string value);

    class EventPublisher
    {
      private string theVal;

      // declare the event
      public event myEventHandler valueChanged;

      public string Val
      {
        set
        {
          theVal = value;
          // when the value changes, fire the event
          valueChanged(theVal);
        }
      }
    }

    public void DoIt()
    {
      // use a named function as an event handler
      EventPublisher obj = new EventPublisher();
      // use an anonymous delegate as an event handler
      obj.valueChanged += delegate (string val) {
        Console.WriteLine("The value changed to {0}", val);
      };

      string str;
      do
      {
        Console.WriteLine("Enter a value: " );
        str = Console.ReadLine();
        if (!str.Equals("exit"))
        {
          obj.Val = str;
        }
      } while (!str.Equals("exit"));
      Console.WriteLine("Goodbye");
    }
  }
}
