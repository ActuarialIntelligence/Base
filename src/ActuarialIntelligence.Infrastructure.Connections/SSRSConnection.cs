using ActuarialIntelligence.Infrastructure.Interfaces.Connection_Interfaces;
using Microsoft.AnalysisServices.AdomdClient;
using Microsoft.AnalysisServices.Tabular;

namespace ActuarialIntelligence.Infrastructure.Connections
{
    /// <summary>
    /// Connect and lode data from SSRS for MDX/DMX query results for post datamining processing/Artificial-Intelligence 
    /// </summary>
    public class SSRSConnection : IQueryDataConnection<AdomdDataReader>
    {
        private readonly AdomdConnection connection;
        public SSRSConnection(string connectionString)
        {
            connection = new AdomdConnection(connectionString);
            Server server = new Server();
            server.Connect(connectionString);
            connection.Open();

        }

        public AdomdDataReader LoadData(string dmxQuery)
        {

            Database db = new Database();
            var command = new AdomdCommand(dmxQuery, connection);
            var reader = command.ExecuteReader();

            return reader;
        }

        public void ClearAndDispose()
        {
            connection.Close();
            connection.Dispose();
        }
    }
}
