using ActuarialIntelligence.Domain.ContainerObjects;
using ActuarialIntelligence.Domain.Mathematical_Technique_Objects;

namespace ActuarialIntelligence.Domain.Financial_Instrument_Objects
{
    /// <summary>
    /// Half yearly bond yield object interpolates and calculates the yield based on bond object parameter.
    /// </summary>
    public class HalfYearlyBondYield
    {
        public BondDetails bondDetails { get; private set; }
        public decimal value { get { return GetValue(); } }

        private decimal cacheValue;

        public HalfYearlyBondYield(BondDetails bondDetails)
        {
            this.bondDetails = bondDetails;
        }

        public decimal GetValue()
        {
            if (cacheValue == 0)
            {
                var bond = new BondHalfYearly(bondDetails.nominal, bondDetails.redemptionRate, bondDetails.yearlyCouponRate, bondDetails.term);
                cacheValue = Interpolation.Interpolate(bond.value, 0.01m, 0.09m, bondDetails.nominal * bondDetails.redemptionRate);
            }
            return cacheValue;
        }
    }
}
