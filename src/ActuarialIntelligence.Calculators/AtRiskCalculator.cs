using ActuarialIntelligence.Calculators.Interfaces;
using ActuarialIntelligence.Domain.PnL;
using ActuarialIntelligence.Infrastructure.Data.Enums;
using ActuarialIntelligence.Infrastructure.Interfaces.Readers_Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActuarialIntelligence.Calculators
{
    /// <summary>
    /// A good idea to spread risk is to possibly be selective of the type of clients we target and onboard at strategic times throughout the year.
    /// </summary>
    public class AtRiskCalculator : ICalculate<AtRisk>
    {
        private readonly Hazard hazard;
        private int type = 0;
        private readonly IDataReaderIntParametric<int> reader;
        private readonly CustomerTimePeriods periodType;

        public CustomerTimePeriods PeriodType => periodType;

        public AtRiskCalculator(Hazard hazard, int type, CustomerTimePeriods periodType, IDataReaderIntParametric<int> reader)
        {
            this.hazard = hazard;
            this.reader = reader;
            this.type = type;
            this.periodType = periodType;
        }

        public AtRisk Calculate()
        {
            var result = reader.GetData(hazard.MaximumSurvivalValueTime, type, periodType);
            var atRisk = new AtRisk((double)hazard.MaximumSurvivalValue, result, periodType);
            return atRisk;
        }
    }
}
