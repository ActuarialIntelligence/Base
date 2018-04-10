using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActuarialIntelligence.Domain.ContainerObjects
{
    public class Nominal
    {
        public decimal nominal { get; private set; }
        public Nominal(decimal nominal)
        {
            this.nominal = nominal;
        }
    }
}
