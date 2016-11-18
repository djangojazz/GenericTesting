using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
  public class DeparmentCollection : SortedDictionary<string, SortedSet<Employee>>
  {
    public DeparmentCollection Add(string deparmentName, Employee employee)
    {
      if (!ContainsKey(deparmentName))
      {
        Add(deparmentName, new SortedSet<Employee>(new EmployeeComparer()));
      }
      this[deparmentName].Add(employee);
      return this;
    }
  }
}
