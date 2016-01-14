using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting.Lambdas
{
  public class LambdaEvents
  {
    public delegate void myEventHandler(string x);

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
      EventPublisher obj = new EventPublisher();

      // Use a Lambda expression to define an event handler
      // Note that this is a statement lambda, due to use of { }
      obj.valueChanged += (x) => {
        Console.WriteLine("The value changed to {0}", x);
      };

      string str;
      do
      {
        Console.WriteLine("Enter a value: ");
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
