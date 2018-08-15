using ActuarialIntelligence.Domain.ContainerObjects;
using System.Collections.Generic;

namespace ActuarialIntelligence.Domain.Calculator_Return_Objects
{
    public class HazardPdfCdfHazardTriplet
    {
        public IList<Point<decimal, decimal>> pdf { get; private set; }
        public IList<Point<decimal, decimal>> cdf { get; private set; }
        public IList<Point<decimal, decimal>> hazard { get; private set; }
        public string startDate { get; private set; }
        public string stateCode { get; private set; }
        public string populationGroupID { get; private set; }
        public HazardPdfCdfHazardTriplet(IList<Point<decimal, decimal>> pdf,
            IList<Point<decimal, decimal>> cdf,
            IList<Point<decimal, decimal>> hazard,
            string startDate, string stateCode, string populationGroupID)
        {
            this.pdf = pdf;
            this.cdf = cdf;
            this.hazard = hazard;
            this.startDate = startDate;
            this.stateCode = stateCode;
            this.populationGroupID = populationGroupID;
        }
    }
}
