using ActuarialIntelligence.Calculators.Interfaces;
using ActuarialIntelligence.Domain.Calculator_Return_Objects;
using ActuarialIntelligence.Domain.Enums;
using ActuarialIntelligence.Infrastructure.Interfaces.Readers_Interfaces;
using Domain;
using Domain.ObservationObjects;
using System;
using System.Collections.Generic;

namespace ActuarialIntelligence.Calculators
{
    public class HazardPDFCalculator : ICalculateParametric<IList<HazardPdfCdfHazardTriplet>, string, int>
    {
        private readonly IDataReaderHazardTransitionParametric<IList<PairedObservation>> hazardReader;
        private string dateFrom, dateTo;
        string transitionCode;
        public HazardPDFCalculator(IDataReaderHazardTransitionParametric<IList<PairedObservation>> hazardReader,
            string dateFrom, string dateTo, string transitionCode)
        {
            this.hazardReader = hazardReader;
            this.dateFrom = dateFrom;
            this.dateTo = dateTo;
            this.transitionCode = transitionCode;
        }
        public IList<HazardPdfCdfHazardTriplet> Calculate(string populationGroup, int currentState)
        {
            var stateTransitionCodes = new List<string>();
            var returnObject = new List<HazardPdfCdfHazardTriplet>();

            Console.WriteLine("Calculating Transition:" + transitionCode);
            
            var observationList = hazardReader.GetData(populationGroup, dateFrom, dateTo,
            new Domain.Date.DateIncrement(DateIncrementTypes.Month, 1), transitionCode, currentState, 1);

            //var nelsonAalen = new KaplanMeier(observationList);
            //var nResult = nelsonAalen.GetSurvivalValueUpToPeriod(periods);
            var hazard = new Hazard(observationList);

            var hzd = hazard.GetHazardFunctionOverEachPeriod();
            var pdf = hazard.GetPDF();
            var cdf = hazard.SurvivalFunction();

            returnObject.Add(new HazardPdfCdfHazardTriplet(pdf, cdf, hzd, dateFrom, transitionCode, populationGroup.ToString()));


            return returnObject;
        }
    }
}
