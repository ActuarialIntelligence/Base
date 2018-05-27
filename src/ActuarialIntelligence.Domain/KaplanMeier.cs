using Domain.ObservationObjects;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class KaplanMeier
    {
        public IList<PairedObservation> observationsInternal { get; private set; }
        public KaplanMeier(IList<PairedObservation> observationsInternal)
        {
            this.observationsInternal = observationsInternal;
        }
        
        public decimal GetSurvivalValueUpToPeriod(int periods)
        {
            var result = 1m;
            var cnt = 0;
            foreach(var observation in observationsInternal)
            {
                try
                {
                    result = result * (1 - (observation.deaths / observation.total));
                    if (cnt == periods - 1)
                    {
                        break;
                    }
                    cnt++;
                }
                catch(DivideByZeroException)
                {
                    result = 0;
                }
            }
            return result;
        }


        public decimal GetSurvivalOverPeriod(int period)
        {
            decimal result = 0;
            try { 
              result =  (1-(observationsInternal[period].deaths / observationsInternal[period].total));
           
            }
            catch (DivideByZeroException)
            {
                result = 0;
            }
            if(result<0)
            {
                result = 0;
            }
            return result;
        }

        public static decimal GetSurvivalValue(IList<PairedObservation> observations,int periods)
        {
            var result = 1m;
            var cnt = 0;
            foreach (var observation in observations)
            {
                try { 
                result = result * (1 - (observation.deaths / observation.total));
                if (cnt == periods - 1)
                {
                    break;
                }
                cnt++;
                }
                catch (DivideByZeroException)
                {
                    result = 0;
                }
            }
            return result;
        }

        public static decimal GetSurvivalOverPeriod(IList<PairedObservation> observations,int period)
        {
            decimal result = 0;
            try { 
             result = (1 - (observations[period - 1].deaths / observations[period - 1].total));
            }
            catch (DivideByZeroException)
            {
                result = 0;
            }
            return result;
        }
    }
}
