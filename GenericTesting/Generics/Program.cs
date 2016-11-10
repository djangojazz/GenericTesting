using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
  class Program
  {
    static void Main(string[] args)
    {
      var buffer = new CircularBuffer<double>();

      ProcessingUserInput(buffer);
      ProcessBuffer(buffer);
    }

    private static void ProcessBuffer(CircularBuffer<double> buffer)
    {
      var sum = 0.0;
      Console.WriteLine("Buffer: ");
      while (!buffer.IsEmpty)
      {
        sum += (Double)buffer.Read();
      }

      Console.WriteLine(sum);
    }

    private static void ProcessingUserInput(CircularBuffer<double> buffer)
    {
      while (true)
      {
        var value = 0.0;
        var input = Console.ReadLine();

        if (double.TryParse(input, out value))
        {
          buffer.Write(value);
          continue;
        }
        break;
      }
    }
  }
}
