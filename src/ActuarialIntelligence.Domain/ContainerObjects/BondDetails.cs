namespace ActuarialIntelligence.Domain.ContainerObjects
{
    public class BondDetails
    {
        public decimal nominal { get; private set; }
        public decimal yearlyCouponRate { get; private set; }
        public decimal redemptionRate { get; private set; }
        public decimal term { get; private set; }
        public decimal inflation { get; private set; }

        public BondDetails(decimal nominal,
            decimal yearlyCouponRate,
            decimal redemptionRate,
            decimal term,
            decimal inflation)
        {
            this.nominal = nominal;
            this.yearlyCouponRate = yearlyCouponRate;
            this.redemptionRate = redemptionRate;
            this.term = term;
            this.inflation = inflation;
        }

    }
}
