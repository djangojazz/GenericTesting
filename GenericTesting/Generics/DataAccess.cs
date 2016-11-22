using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Generics
{
  public class EmployeeDb : DbContext
  {
    public EmployeeDb() : base("Employees") { }
    public DbSet<Employee> Employees { get; set; }
  }

  public interface IRepository<T> : IDisposable
  {
    void Add(T newEntity);
    void Delete(T entity);
    T FindById(int id);
    IQueryable<T> FindAll();
    int Commit();
  }

  public class SqlRepository<T> : IRepository<T> where T : class
  {
    DbContext _ctx;
    DbSet<T> _set;

    public SqlRepository(DbContext ctx)
    {
      _ctx = ctx;
      _set = _ctx.Set<T>();
    }

    public void Add(T newEntity)
    {
      _set.Add(newEntity);
    }
    
    public void Delete(T entity)
    {
      throw new NotImplementedException();
    }

    public T FindById(int id)
    {
      throw new NotImplementedException();
    }

    public IQueryable<T> FindAll()
    {
      return _set;
    }

    public int Commit()
    {
      return _ctx.SaveChanges();
    }

    public void Dispose()
    {
      _ctx.Dispose();
    }
  }
}
