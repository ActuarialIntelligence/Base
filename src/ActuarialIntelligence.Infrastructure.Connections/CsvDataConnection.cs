using ActuarialIntelligence.Infrastructure.Interfaces.Connection_Interfaces;
using FileHelpers;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ActuarialIntelligence.Infrastructure.Connections
{
    /// <summary>
    /// Filehelper-Engine based connection object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CsvDataConnection<T> : IDataConnection<IList<T>> where T : class
    {
        private readonly FileHelperEngine<T> engine;
        private string path;
        public CsvDataConnection(string path)
        {
            engine = new FileHelperEngine<T>();
            this.path = path;
        }

        public virtual IList<T> LoadData()
        {
            using (var fileStream = new FileStream(path
                , FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var streamReader = new StreamReader(fileStream))
            {
                return engine.ReadStream(streamReader).ToList();
            }
        }

    }
}
