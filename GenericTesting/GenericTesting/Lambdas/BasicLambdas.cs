using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting.Lambdas
{
  public class BasicLambdas
  {
    public delegate int MyDelegate(int x);
    public delegate void MyDelegate2(int x, string prefix);
    public delegate bool ExprDelegate(int x);

    public void DoIt()
    {
      MyDelegate foo = (x) => x * x;
      Console.WriteLine($"The result of foo is: {foo(5)}");

      // Dynamically change the delegate to something else
      foo = (x) => x * 10;
      Console.WriteLine($"The result of bar is: {foo(5)}");

      // Create a delegate that takes multiple arguments
      MyDelegate2 bar = (x, y) => {
        Console.WriteLine($"The two-arg lambda: {x*10}, {y}");
      };
      bar(25, "Some string");

      // Define an expression delegate
      ExprDelegate baz = (x) => x > 10;
      Console.WriteLine("Calling baz with 5: {0}", baz(5));
      Console.WriteLine("Calling bax with 15: {0}", baz(15));

      Console.WriteLine("\nPress Enter to Continue...");
      Console.ReadLine();
    }
  }
}
