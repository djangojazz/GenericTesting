using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting
{
  public class AnnonymousDelegates
  {
    public delegate string MyDelegate(int arg1, int arg2);
    
    public void ReturnData()
    {
      MyDelegate f = delegate (int arg1, int arg2)
      {
        return (arg1 + arg2).ToString();
      };
      Console.WriteLine("The number is: " + f(10, 20));

      Console.WriteLine("\nPress Enter to Continue...");
      Console.ReadLine();
    }
  }
}
