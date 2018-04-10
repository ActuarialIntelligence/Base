using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActuarialIntelligence.Domain.ContainerObjects
{
    public class NominalCashflowSet
    {
        public Nominal Nominal { get; private set; }
        public ListTermCashflowSet cashFlowSet
        { get; private set; }

        public NominalCashflowSet(Nominal Nominal, ListTermCashflowSet cashFlowSet)
        {
            this.Nominal = Nominal;
            this.cashFlowSet = cashFlowSet;
        }
    }
}
