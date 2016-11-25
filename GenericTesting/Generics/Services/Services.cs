using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Services
{
  public interface ILogger
  {
  }

  public class SqlServerLogger : ILogger
  {

  }

  public interface IRepository<T>
  {

  }


  public class SqlRepository<T> : IRepository<T>
  {
    public SqlRepository(ILogger logger)
    {

    }
  }
  
  public class Customer
  {

  }

  public class InvoiceService
  {
    public InvoiceService(IRepository<Employee> repository, ILogger logger)
    {

    }
  }

}
