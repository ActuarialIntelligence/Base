using ActuarialIntelligence.Infrastructure.Interfaces.Connection_Interfaces;
using System.Data.Common;
using System.Data.Odbc;

namespace ActuarialIntelligence.Infrastructure.Connections
{
    /// <summary>
    /// Connect and load data from HIVE
    /// </summary>
    public class HIVEConnection : IDataConnection<DbDataReader>
    {
        public DbDataReader LoadData()
        {
            DbDataReader dr;
            using (OdbcConnection conn =
             new OdbcConnection("DSN=Hive;UID=user-name;PWD=password"))//Example
            {
                conn.OpenAsync().Wait();
                OdbcCommand cmd = conn.CreateCommand();
                cmd.CommandText =
                    "SELECT obs_date, avg(temp) FROM weather GROUP BY obs_date;";//Example
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                }
                conn.Close();
            }
            return dr;
        }
    }
}
