using System;

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
