using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActuarialIntelligence.Domain
{
    public class Identifier
    {
        public string key { get; private set; }
        public Guid ID { get; private set; }
        public Identifier(string key, Guid ID)
        {
            this.key = key;
            this.ID = ID;
        }
    }
}
