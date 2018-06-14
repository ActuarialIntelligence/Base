using ActuarialIntelligence.Infrastructure.Interfaces.Connection_Interfaces;
using ActuarialIntelligence.Infrastructure.Interfaces.Readers_Interfaces;
using Microsoft.AnalysisServices.AdomdClient;
using System.Collections.Generic;

namespace ActuarialIntelligence.Infrastructure.Readers
{
    public class ModelStatesSuggestionReader : IDataReader<IList<string>>
    {
        private readonly IQueryDataConnection<AdomdDataReader> connection;
        private int noOfClusters;
        private int stateRange;
        public ModelStatesSuggestionReader(IQueryDataConnection<AdomdDataReader> connection
            , int noOfClusters, int stateRange)
        {
            this.connection = connection;
            this.noOfClusters = noOfClusters;
            this.stateRange = stateRange;
        }

        public void ClearAndDispose()
        {
            connection.ClearAndDispose();
        }

        public IList<string> GetData()
        {
            var codeList = new List<int>();
            CreateCodeList(codeList);
            var suggestionCodes = new List<string>();

            for (int i = 1; i <= noOfClusters; i++)
            {
                foreach (int c in codeList)
                {
                    var reader = connection.LoadData("SELECT ClusterProbability('Cluster " + i + "') " +
                        "as [probability] FROM[Transitions String Encoded] NATURAL " +
                        "PREDICTION JOIN (SELECT '" + c + "' AS[State Transition Code]) AS t");
                    reader.Read();
                    var tmp = reader[0].ToString().Length > 5 ? reader[0].ToString().Substring(0, 5) : reader[0].ToString();
                    if (decimal.Parse(tmp) >= 0.2m)
                    {
                        suggestionCodes.Add(c + "|" + decimal.Parse(tmp));
                    }
                    reader.Dispose();
                }
            }

            return suggestionCodes;
        }

        private void CreateCodeList(List<int> codeList)
        {
            for (int i = 1; i <= stateRange; i++)
            {
                for (int j = 1; j <= stateRange; j++)
                {
                    codeList.Add(int.Parse(i.ToString() + j.ToString()));
                }
            }
        }
    }
}
