using ActuarialIntelligence.Calculators.Interfaces;
using ActuarialIntelligence.Infrastructure.Interfaces.Readers_Interfaces;
using Domain;
using System.Collections.Generic;

namespace ActuarialIntelligence.Calculators
{
    public class ChapmanKolmogorovCalculator : ICalculateParametric<ChapmanKolmogorov, int, int, string>
    {
        private readonly IDataReaderIdParametric<IList<string>> transitionCodesReader;
        public ChapmanKolmogorovCalculator(IDataReaderIdParametric<IList<string>> transitionCodesReader)
        {
            this.transitionCodesReader = transitionCodesReader;
        }
        public ChapmanKolmogorov Calculate(int id, int stateId, string startDate)
        {
            var hazards = new List<DBHazardPDF>();
            var codes = transitionCodesReader.GetData(id);
            foreach (var code in codes)
            {
                if (code.Substring(0, 1) == stateId.ToString())
                {
                    var hazard = new DBHazardPDF(new StatAIEntities(), int.Parse(code), id.ToString(), startDate);
                    hazards.Add(hazard);
                }
            }

            return new ChapmanKolmogorov(hazards, id);
        }
    }
}
