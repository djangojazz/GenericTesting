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
      var employeesByName = new Dictionary<string, List<Employee>>();
      employeesByName.Add("Development", 
          new List<Employee> { new Employee { Name = "Brett" } });

      employeesByName["Development"].Add(new Employee { Name = "Jonhn" });

      foreach (var item in employeesByName)
      {
        foreach (var employee in item.Value)
        {
          Console.WriteLine(employee.Name);
        }
      }
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
