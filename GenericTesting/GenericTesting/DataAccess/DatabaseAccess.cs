using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting.DataAccess
{
  public static class DatabaseAccess
  {
    public const string TesterDatabase = "data source=(local);initial catalog=Tester;Integrated Security=False;password=pa55word;user id=sqluser;Connect Timeout=40;";
    public const string CentralTestDatabase = "data source=DEV-ENTERPRISE;initial catalog=PSG_APC_CENTRAL;Integrated Security=False;password=pa55word;user id=sqluser;Connect Timeout=40;";
    public const string EnterpriseTestDatabase = "data source=DEV-ENTERPRISE;initial catalog=PSG_ENTERPRISE;Integrated Security=False;password=pa55word;user id=sqluser;Connect Timeout=40;";
  }
}
