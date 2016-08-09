using System;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket
{
  public sealed class SimpleAuthenticationService : IAuthenticationService
  {
    //private readonly SimpleDataContext data;

    public SimpleAuthenticationService()
    {
      //data = SimpleDataContext.DemoData;
    }

    public async Task<Guid?> AuthenticateUserAsync(string user, string password)
    {
      await Task.Delay(2000);

      //Guid? id = data.Users
      //              .Where(u => u.UserName == user && u.Password == password)
      //              .Select(u => (Guid?)u.Id)
      //              .SingleOrDefault();

      Guid? id = new Guid();

      return id; 
    }
  }
}
