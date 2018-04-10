using ActuarialIntelligence.Domain.ContainerObjects;
using System;

namespace ActuarialIntelligence.Domain.Financial_Instrument_Objects
{
    /// <summary>
    /// Annuity object at : i + i_z
    /// </summary>
    public class ZSpreadSpecificAnnuity
    {
        private readonly ListTermCashflowSet cashFlowSet;
        private int days;
        public ZSpreadSpecificAnnuity(ListTermCashflowSet cashFlowSet, int days)
        {
            this.cashFlowSet = cashFlowSet;
            this.days = days;
        }

        public decimal GetPV(decimal zSpread)
        {
            var total = 0m;
            DateTime anchorDate = cashFlowSet.AnchorDate;
            foreach (var cashFlow in cashFlowSet.CashflowSet)
            {
                total += cashFlow.cashflow * discountFactor(cashFlow.spotYield.Yield + zSpread,
                    cashFlowSet.DifferenceInUnitsBetweenDates(anchorDate, cashFlow.date, days));
            }
            return total;
        }

        private decimal discountFactor(decimal yield, decimal term)
        {
            var d = (1 / (1 + yield));
            var dp = Math.Pow((double)d, (double)term);
            return (decimal)dp;
        }
    }
}
