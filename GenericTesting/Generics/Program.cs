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
      Queue<Employee> queue = new Queue<Employee>();
      queue.Enqueue(new Employee { Name = "Alex" });
      queue.Enqueue(new Employee { Name = "Brett" });
      queue.Enqueue(new Employee { Name = "Jon" });

      while(queue.Count > 0)
      {
        var employee = queue.Dequeue();
        Console.WriteLine(employee.Name);
      }

      Console.WriteLine("----");

      Stack<Employee> stack = new Stack<Employee>();
      stack.Push(new Employee { Name = "Alex" });
      stack.Push(new Employee { Name = "Brett" });
      stack.Push(new Employee { Name = "Jon" });

      while (stack.Count > 0)
      {
        var employee = stack.Pop();
        Console.WriteLine(employee.Name);
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
