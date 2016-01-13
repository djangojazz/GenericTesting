using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting.Events
{
  public class ChainedEvents
  {
    private string theVal;
    public delegate void myEventHandler(string value);
    public event myEventHandler valueChanged;
    public event EventHandler<ObjChangeEventArgs> objChanged;

    public string Val
    {
      set
      {
        theVal = value;
        // when the value changes, fire the event
        valueChanged(theVal);
        this.objChanged(this, new ObjChangeEventArgs() { propChanged = "Val" });
      }
    }
    
    public void DoIt()
    {
      // use a named function as an event handler
      valueChanged += changeListener1;
      valueChanged += changeListener2;

      // Use an anonymous delegate as the event handler
      valueChanged += delegate (string s) {
        Console.WriteLine("This came from the anonymous handler!");
      };

      objChanged += delegate (object sender, ObjChangeEventArgs e) {
        Console.WriteLine("{0} had the '{1}' property changed", sender.GetType(), e.propChanged);
      };

      string str;
      do
      {
        Console.WriteLine("Enter a value: ");
        str = Console.ReadLine();
        if (!str.Equals("exit"))
        {
          this.Val = str;
        }
      } while (!str.Equals("exit"));
      Console.WriteLine("Goodbye");
    }

    static void changeListener1(string value)
    {
      Console.WriteLine($"The value changed to {value}");
    }

    static void changeListener2(string value)
    {
      Console.WriteLine($"I also listen to the event, and got {value}");
    }

    public class ObjChangeEventArgs : EventArgs
    {
      public string propChanged;
    }

    
  }
}
