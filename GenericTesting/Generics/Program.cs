using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
  public class EmployeeComparer : IEqualityComparer<Employee>, IComparer<Employee>
  {
    public bool Equals(Employee x, Employee y)
    {
      return String.Equals(x.Name, y.Name);
    }

    public int GetHashCode(Employee obj)
    {
      return obj.Name.GetHashCode();
    }

    public int Compare(Employee x, Employee y)
    {
      return String.Compare(x.Name, y.Name);
    }
  }

  public class DeparmentCollection : SortedDictionary<string, SortedSet<Employee>>
  {
    public DeparmentCollection Add(string deparmentName, Employee employee)
    {
      if(!ContainsKey(deparmentName))
      {
        Add(deparmentName, new SortedSet<Employee>(new EmployeeComparer()));
      }
      this[deparmentName].Add(employee);
      return this;
    }
  }

  class Program
  {
    static void Main(string[] args)
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

      Console.ReadLine();
    }

    private static void RunBufferProgram()
    {
      var buffer = new Buffer<double>();

      ProcessInput(buffer);

      foreach (var item in buffer)
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
