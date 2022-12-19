using System.Collections.Generic;
using System.Linq;

namespace ActuarialIntelligence.Domain
{
    public class ObjectStorePatternDominObject
    {
        public IDictionary<Identifier, string> rows { get; private set; }
        public ObjectStorePatternDominObject()
        {

        }
        public ObjectStorePatternDominObject(IDictionary<Identifier, string> rows)
        {
            this.rows = rows;
        }

        public IList<string[]> Getwhere(Identifier ID, char delimiter)
        {
            var list = new List<string[]>();
            var result = rows.Where(r => r.Key.ID == ID.ID && r.Key.key == ID.key).Select(g => g.Value).ToList();
            foreach(var val in result)
            {
                list.Add(val.Split(delimiter));
            }
            return list;
        }

        public bool IsIrregular(char delimiter)
        {
            var cnt = rows.First().Value.Split(delimiter).Count();

            foreach(var r in rows)
            {
                if(r.Value.Split(delimiter).Count() != cnt)
                {
                    return true;
                    
                }
            }
            return false;

        }
    }
    public class ObjectStorePatternObject
    {
        public IDictionary<Identifier, string> rows { get; set; }
    }
}
