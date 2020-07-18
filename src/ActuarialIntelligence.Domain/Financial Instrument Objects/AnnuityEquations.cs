

namespace ActuarialIntelligence.Domain.Financial_Instrument_Objects
{
    public class AnnuityEquations
    {
        private readonly Annuity annuity1;
        private readonly Annuity annuity2;
    public AnnuityEquations(Annuity annuity1, 
        Annuity annuity2)
        {
            this.annuity1 = annuity1;
            this.annuity2 = annuity2;      
        }

        public decimal ZSpreadOfAnnuityModel(decimal zSpread)
        {
            return 7.14m * annuity1.GetZSpreadPV(zSpread) 
                - 2 * annuity2.GetZSpreadPV(zSpread);
        }
    }
}
