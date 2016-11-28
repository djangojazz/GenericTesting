using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Generics.BufferExtensions;

namespace Generics
{
  class Program
  {
    public enum Steps
    {
      Step1,
      Step2,
      Step3
    } 

    static void Main(string[] args)
    {
      var input = "Step1";
      Steps value = input.ParseEnum<Steps>();
      Console.WriteLine(value);

      Console.ReadLine();
    }

    private static void CreateCollectionWithReflection()
    {
      var employeeList = CreateCollection(typeof(List<>), typeof(Employee));
      Console.Write(employeeList.GetType().Name);
      var genericArguments = employeeList.GetType().GenericTypeArguments;
      foreach (var arg in genericArguments)
      {
        Console.Write($"[{arg.Name}]");
      }

      var employee = new Employee();
      var employeeType = typeof(Employee);
      var methodInfo = employeeType.GetMethod("Speak");
      methodInfo = methodInfo.MakeGenericMethod(typeof(DateTime));
      methodInfo.Invoke(employee, null);
    }

    private static object CreateCollection(Type collectionType, Type itemType)
    {
      var closedType = collectionType.MakeGenericType(itemType);
      return Activator.CreateInstance(closedType);
    }

    private static void RepositoryExample()
    {
      Database.SetInitializer(new DropCreateDatabaseAlways<EmployeeDb>());

      using (IRepository<Employee> employeeRepository = new SqlRepository<Employee>(new EmployeeDb()))
      {
        AddEmployees(employeeRepository);
        AddManagers(employeeRepository);
        CountEmployees(employeeRepository);
        QueryEmployees(employeeRepository);
        DumpPeople(employeeRepository);
      }
    }

    private static void AddManagers(IWriteOnlyRepository<Manager> employeeRepository)
    {
      employeeRepository.Add(new Manager { Name = "Chris" });
      employeeRepository.Commit();
    }

    private static void DumpPeople(IReadOnlyRepository<Person> employeeRepository)
    {
      var employees = employeeRepository.FindAll();
      foreach (var employee in employees)
      {
        Console.WriteLine(employee.Name);
      }
    }

    private static void QueryEmployees(IRepository<Employee> employeeRepository)
    {
      var employee = employeeRepository.FindById(1);
      Console.WriteLine(employee.Name);
    }

    private static void CountEmployees(IRepository<Employee> employeeRepository)
    {
      Console.WriteLine(employeeRepository.FindAll().Count());
    }

    private static void AddEmployees(IRepository<Employee> employeeRepository)
    {
      employeeRepository.Add(new Employee { Name = "Brett" });
      employeeRepository.Add(new Employee { Name = "John" });
      employeeRepository.Commit();
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

    #region "Buffer Methods"
    private static void RunBufferProgram()
    {
      var buffer = new CircularBuffer<double>(capacity: 3);
      buffer.ItemDiscarded += ItemDiscarded;

      ProcessInput(buffer);
      buffer.Dump(d => Console.WriteLine(d));

      ProcessBuffer(buffer);
    }

    private static void ItemDiscarded(object sender, ItemDiscardedEventArgs<double> e)
    {
      Console.WriteLine($"Buffer full. Discarding {e.ItemDiscarded} New item is {e.NewItem}");
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
    #endregion
  }
}
