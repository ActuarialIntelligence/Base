using System.Collections.Generic;
using System.Linq;

namespace ActuarialIntelligence.Domain
{
    public class ObjectStorePatternObject
    {
        public IDictionary<Identifier, string[]> rows { get; private set; }
        public ObjectStorePatternObject()
        {

        }
        public ObjectStorePatternObject(IDictionary<Identifier, string[]> rows)
        {
            this.rows = rows;
        }

        public IList<string[]> Getwhere(Identifier ID)
        {
            var result = rows.Where(r => r.Key.ID == ID.ID && r.Key.key == ID.key).Select(g => g.Value).ToList();
            return result;
        }
    }
}
