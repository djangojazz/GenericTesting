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
      RunBufferProgram();

      Console.ReadLine();
    }

    private static void DepartmentCollectionFun()
    {
      var departments = new DeparmentCollection();

      departments.Add("Sales", new Employee { Name = "Emily" })
          .Add("Sales", new Employee { Name = "Chris" })
          .Add("Sales", new Employee { Name = "Emily" });

      departments.Add("Engineering", new Employee { Name = "Brett" })
        .Add("Engineering", new Employee { Name = "Mark" })
        .Add("Engineering", new Employee { Name = "John" });


      foreach (var item in departments)
      {
        Console.WriteLine(item.Key);
        foreach (var employee in item.Value)
        {
          Console.WriteLine("\t" + employee.Name);
        }
      }
    }

    private static void RunBufferProgram()
    {
      var buffer = new Buffer<double>();

      ProcessInput(buffer);

      var asInts = buffer.AsEnumerable<int>();

      foreach (var item in asInts)
      {
        Console.WriteLine(item);
      }

      ProcessBuffer(buffer);
    }

    private static void ProcessBuffer(IBuffer<Double> buffer)
    {
      var sum = 0.0;
      Console.WriteLine("Buffer: ");
      while (!buffer.IsEmpty)
      {
        sum += (Double)buffer.Read();
      }

      Console.WriteLine(sum);
    }

    private static void ProcessInput(IBuffer<double> buffer)
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
