using System;

namespace ActuarialIntelligence.Domain.ContainerObjects
{
    public class TermCashflowYieldSet : IEquatable<TermCashflowYieldSet>
    {
        public decimal cashflow { get; private set; }
        public decimal term { get; private set; }
        public DateTime date { get; private set; }
        public SpotYield spotYield { get; private set; }

        public TermCashflowYieldSet(decimal cashflow,
                                    decimal term,
                                    DateTime date,
                                    SpotYield spotYield)
        {
            this.cashflow = cashflow;
            this.term = term;
            this.date = date;
            this.spotYield = spotYield;
        }

        public bool Equals(TermCashflowYieldSet other)
        {
            throw new NotImplementedException();
        }
    }
}
