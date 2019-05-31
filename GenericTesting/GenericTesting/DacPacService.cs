using Microsoft.SqlServer.Dac;

namespace GenericTesting
{
    public sealed class DacPacService
    {
        public void CreateDatabaseFromDacPac(string connection, string dacpacLocation, string dbName)
        {
            try
            {
                var ds = new DacServices(connection);
                using (DacPackage dp = DacPackage.Load(dacpacLocation))
                {
                    ds.Deploy(dp, dbName, upgradeExisting: false, options: null, cancellationToken: null);
                }
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}
