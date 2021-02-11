using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KubernetesLogAnalyticsConnector
{
    public class QueryResults
    {
        public QueryResults() { }
        public QueryResults(IList<Table> tables) { }

        [JsonProperty(PropertyName = "results")]
        public IEnumerable<IDictionary<string, string>> Results { get; }
        public IDictionary<string, string> Render { get; set; }
        public IDictionary<string, object> Statistics { get; set; }
        [JsonProperty(PropertyName = "tables")]
        public IList<Table> Tables { get; set; }

        public virtual void Validate() { }
    }
    public class Table
    {
        public Table() { }
        public Table(string name, IList<Column> columns, IList<IList<string>> rows) { }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "columns")]
        public IList<Column> Columns { get; set; }
        [JsonProperty(PropertyName = "rows")]
        public IList<IList<string>> Rows { get; set; }

        public virtual void Validate() { }
    }

    public class Column
    {
        public Column() { }
        public Column(string name = null, string type = null) { }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
