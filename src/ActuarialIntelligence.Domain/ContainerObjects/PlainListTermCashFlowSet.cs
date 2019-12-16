using ActuarialIntelligence.Domain.Enums;
using System;
using System.Collections.Generic;

namespace ActuarialIntelligence.Domain.ContainerObjects
{
    public class PlainListTermCashFlowSet
    {
        public IList<TermCashflowYieldSet> cashflowSet;
        public DateTime anchorDate;
        public Term termType;
        public decimal  nominal;
    }
}
