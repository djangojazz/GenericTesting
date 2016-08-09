using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
  public interface IAuthenticationService
  {
    /// <summary>
    /// Authenticates the given user/password, returning the user's ID as a GUID on success, or null on a failure
    /// </summary>
    Task<Guid?> AuthenticateUserAsync(string user, string password);
  }
}
