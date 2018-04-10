using System;

namespace ActuarialIntelligence.Domain.Financial_Instrument_Objects
{
    /// <summary>
    /// Bi-Annual bond object
    /// </summary>
    public class BondHalfYearly
    {
        private decimal nominal;
        private decimal yearlyCouponRate;
        private decimal termToMaturity;
        private decimal redemptionRate;
        public BondHalfYearly(decimal nominal, decimal redemptionRate, decimal yearlyCouponRate, decimal termToMaturity)
        {
            this.nominal = nominal;
            this.yearlyCouponRate = yearlyCouponRate;
            this.termToMaturity = termToMaturity;
            this.redemptionRate = redemptionRate;
        }

        public decimal value(decimal yieldRate)
        {
            decimal presentValue = 0;
            decimal i = 0.5m;
            while (i < termToMaturity)
            {
                presentValue += nominal * (yearlyCouponRate / 2) * discountFactorValue(yieldRate, i);
                i += 0.5m;
            }
            presentValue += nominal * (redemptionRate + (yearlyCouponRate / 2)) * discountFactorValue(yieldRate, i);
            return presentValue;
        }

        private static decimal discountFactorValue(decimal yieldRate, decimal term)
        {
            var discountFactor = Math.Pow((1 / (double)(1 + yieldRate)), (double)(term));
            return (decimal)discountFactor;
        }
    }
}
