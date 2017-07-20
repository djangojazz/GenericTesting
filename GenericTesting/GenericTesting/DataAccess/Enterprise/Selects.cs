using CSharpDataAccess.Enterprise.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; 
using System.Linq;

namespace GenericTesting.DataAccess.Enterprise
{
  public static class Selects
  {
    public static IList<T> RunQuery<T>(string proc, List<SqlParameter> parms = null)
    {
      using (var cn = new SqlConnection(DatabaseAccess.EnterpriseTestDatabase))
      {
        using (var cmd = new SqlCommand(proc, cn))
        {
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandTimeout = 60;

          if (parms != null)
            parms.ForEach(parm => cmd.Parameters.Add(parm));

          using (SqlDataAdapter adapter = new SqlDataAdapter())
          {
            using (DataTable table = new DataTable())
            {
              cn.Open();
              adapter.SelectCommand = cmd;
              table.Locale = System.Globalization.CultureInfo.InvariantCulture;
              adapter.Fill(table);
              cn.Close();

              return DataConverter.ConvertTo<T>(table);
            }
          }
        }
      }
    }

    public static List<DemandTrendOutput> GetDemandTrends(string serialized)
    {
      dynamic @params = new List<SqlParameter> { new SqlParameter("@Input", serialized) };
      return RunQuery<DemandTrendOutput>("vis.SelectDemandTrendDetails", @params);
    }

    public static List<DemandLocation> GetDemandLocations()
    {
      var items = RunQuery<DemandLocationDb>("vis.ListLocations");
      return items.ToList().Select(x => new DemandLocation(x.GDKEY, x.Company, x.Division, x.Branch, x.Name)).ToList();
    }

    public static List<TestDefinitionComponent> GetTestDefintionComponents(int testDefinitionId, DateTime versionUTC)
    {
      dynamic @params = new List<SqlParameter>
      {
        new SqlParameter("@TestDefinitionId", testDefinitionId),
        new SqlParameter("@VersionUTC", versionUTC)
      };
      var items = RunQuery<TestDefinitionComponent>("qc.ListTestDefinitionComponents", @params);
      return items;
    }

    public static List<TestDefinition2> GetTestDefintion2(int testDefinitionId, DateTime versionUTC)
    {
      dynamic @params = new List<SqlParameter>
      {
        new SqlParameter("@TestDefinitionId", testDefinitionId),
        new SqlParameter("@VersionUTC", versionUTC)
      };
      var items = RunQuery<TestDefinition2>("qc.ListTestDefinitions2", @params);
      return items;
    }
  }
}