using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting
{
  public class BasicDelegates.Delegates
  {
    public delegate string MyDelegate(int arg1, int arg2);

    static string func1(int a, int b)
    {
      return (a + b).ToString();
    }

    static string func2(int a, int b)
    {
      return (a * b).ToString();
    }

    class MyClass
    {
      public string instanceMethod1(int arg1, int arg2)
      {
        return ((arg1 + arg2) * arg1).ToString();
      }
    }

    public void ReturnData()
    {
      MyDelegate f = func1;
      Console.WriteLine("The number is: " + f(10,20));
      f = func2;
      Console.WriteLine("The number is: " + f(10,20));
      f = new MyClass().instanceMethod1;
      Console.WriteLine("The number is: " + f(10,20));

      Console.WriteLine("\nPress Enter to Continue...");
      Console.ReadLine();
    }
  }
}
