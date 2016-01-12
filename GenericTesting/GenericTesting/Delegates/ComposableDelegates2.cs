using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting
{
  public class ComposableDelegates2
  {
    public delegate void MyDelegate(int arg1, ref int arg2);

    static void func1(int arg1, ref int arg2)
    {
      string result = (arg1 + arg2).ToString();
      arg2 += 20;
      Console.WriteLine("The number is: " + result);
    }

    static void func2(int arg1, ref int arg2)
    {
      string result = (arg1 * arg2).ToString();
      Console.WriteLine("The number is: " + result);
    }

    public void ReturnData()
    {
      MyDelegate f1 = func1;
      MyDelegate f2 = func2;
      MyDelegate f1f2 = f1 + f2;
      int a = 10, b = 10;

      Console.WriteLine("Calling the first delegate");
      f1(a, ref b);
      Console.WriteLine("The value of b is: " + b);
      Console.WriteLine("Calling the second delegate");
      f2(a, ref b);
      Console.WriteLine("The value of b is: " + b);
      Console.WriteLine("Calling the chained delegate");
      f1f2(a, ref b);
      Console.WriteLine("The value of b is: " + b);

      Console.WriteLine("\nPress Enter to Continue...");
      Console.ReadLine();
    }
  }
}
