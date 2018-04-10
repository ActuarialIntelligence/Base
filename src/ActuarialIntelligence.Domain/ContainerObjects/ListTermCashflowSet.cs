using ActuarialIntelligence.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ActuarialIntelligence.Domain.ContainerObjects
{
    public class ListTermCashflowSet
    {
        private IList<TermCashflowYieldSet> cashflowSet;
        private DateTime anchorDate;
        public Term termType { get; private set; }
        public IList<TermCashflowYieldSet> CashflowSet
        {
            get
            {
                var result = cashflowSet.Where(r => r.spotYield.Term.Equals(termType)).OrderBy(e => e.date).ToList();
                return result;
            }
        }
        public DateTime AnchorDate { get { return anchorDate = cashflowSet.First().date; } }
        public ListTermCashflowSet(IList<TermCashflowYieldSet> cashflowSet, Term termType)
        {
            this.cashflowSet = cashflowSet;
            this.termType = termType;
        }

        public void AddCashflows(IList<TermCashflowYieldSet> cashflows)
        {
            cashflowSet.Union(cashflows);
        }

        public decimal DifferenceInUnitsBetweenDates(DateTime dateA, DateTime dateB, int unitScale)
        {
            int remainder = 0;
            int days = (dateB - dateA).Days;
            int quotient = Math.DivRem(days, unitScale, out remainder);
            var result = quotient + remainder / unitScale;
            return result;
        }
    }
}
