using ActuarialIntelligence.Infrastructure.Data.Enums;

namespace ActuarialIntelligence.Domain.PnL
{
    public class AtRisk
    {
        public double ProbabilityValue { get; private set; }
        public double NoAtRisk { get; private set; }
        public CustomerTimePeriods customerTimePeriods { get; private set; }
        public AtRisk(double probabilityValue, double noAtRisk, CustomerTimePeriods customerTimePeriods)
        {
            this.ProbabilityValue = probabilityValue;
            this.NoAtRisk = noAtRisk;
            this.customerTimePeriods = customerTimePeriods;
        }
    }
}
