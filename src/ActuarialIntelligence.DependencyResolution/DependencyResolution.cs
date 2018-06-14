using ActuarialIntelligence.Infrastructure.Connections;
using ActuarialIntelligence.Infrastructure.Interfaces.Readers_Interfaces;
using ActuarialIntelligence.Infrastructure.Readers;
using System.Collections.Generic;

namespace ActuarialIntelligence.DependencyResolution
{
    public static class DependencyResolution
    {
        public static IDataReader<IList<string>> GetDMXMDXReader(int noOfClusters, int stateRange)
        {
            var con = new SSRSConnection("Provider=MSOLAP;integrated security=SSPI;Data Source = JYP1510\\MULTINODESSAS; Initial Catalog =StatAIDataMining");
            var reader = new ModelStatesSuggestionReader(con, noOfClusters, stateRange);
            return reader;
        }
    }
}
