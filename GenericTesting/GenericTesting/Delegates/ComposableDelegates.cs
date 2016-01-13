using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting.Delegates
{
  public class ComposableDelegates
  {
    public delegate void MyDelegate(int arg1, int arg2);

    static void func1(int a, int b)
    {
      string result = (a + b).ToString();
      Console.WriteLine("The number is: " + result);
    }

    static void func2(int a, int b)
    {
      string result = (a * b).ToString();
      Console.WriteLine("The number is: " + result);
    }

    public void ReturnData()
    {
      MyDelegate f1 = func1;
      MyDelegate f2 = func2;
      MyDelegate f1f2 = f1 + f2;

      Console.WriteLine("Calling the first delegate");
      f1(10, 20);
      Console.WriteLine("Calling the second delegate");
      f2(10, 20);
      Console.WriteLine("Calling the chained delegate");
      f1f2(10, 20);

      Console.WriteLine("Calling the unchained delegate");
      f1f2 -= f1;
      f1f2(10, 20);

      Console.WriteLine("\nPress Enter to Continue...");
      Console.ReadLine();
    }
  }
}
