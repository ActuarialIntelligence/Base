using ActuarialIntelligence.Domain.ContainerObjects;
using Domain.ObservationObjects;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class Hazard
    {
        public IList<PairedObservation> observationsInternal { get; private set; }
        private KaplanMeier nelsonAalen;
        public int StateID { get; set; }
        private IList<Point<decimal, decimal>> cache;
        public Hazard(IList<PairedObservation> observationsInternal)
        {
            this.observationsInternal = observationsInternal;
        }

        public IList<Point<decimal, decimal>> GetHazardFunctionOverEachPeriod()
        {
            nelsonAalen = new KaplanMeier(observationsInternal);
            var result = new List<Point<decimal, decimal>>();
            var cnt = 0;
           
            foreach (var set in observationsInternal)
            {
                    var survival = nelsonAalen.GetSurvivalOverPeriod(cnt);
                    var v1 = survival==0?0:(-1) * Math.Log((double)survival);
                    var v2 = (double)(set.unitTime);
                    var div = (decimal)((-1) * v1 / v2);
                   
                    var point = new Point<decimal, decimal>(set.unitTime * cnt, (div));
                    result.Add(point);
                   
                    cnt++;

            }
            return result;
        }
        /// <summary>
        /// S(t)*λ(x) = f(t) 
        /// For use in Kolmogorov.
        /// </summary>
        /// <returns></returns>
        public IList<Point<decimal, decimal>> GetHazardsOverPeriods()
        {
           
            var result = new List<Point<decimal, decimal>>();
            var hazards = GetHazardFunctionOverEachPeriod();
            var cnt = 0;
            foreach (var obs in observationsInternal)
            {
                var point = new Point<decimal, decimal>(obs.unitTime * cnt, (hazards[cnt].Yval));//Survival : CDF => staying in current state up until time t.
                result.Add(point);
                cnt++;
            }
            return result;
        }

        public IList<Point<decimal, decimal>> GetPDFTimesUnitTime()
        {
            var result = new List<Point<decimal, decimal>>();
            var hazards = GetHazardFunctionOverEachPeriod();
            var cnt = 0;
            foreach (var obs in observationsInternal)
            {
                var exponent = ((-1) * hazards[cnt].Yval * obs.unitTime);
                var exponentE = Math.Pow(Math.E, (double)(exponent));
                var v1 = hazards[cnt].Yval;
                var v2 = obs.unitTime;
                var res = v1 * v2 * (decimal)exponentE;
                var point = new Point<decimal, decimal>(obs.unitTime * cnt, (obs.unitTime * hazards[cnt].Yval * 
                    (decimal)Math.Pow(Math.E, (double)((-1) * hazards[cnt].Yval * obs.unitTime))));//Survival : CDF => staying in current state up until time t.
                result.Add(point);
                cnt++;
            }
            return result;
        }

        public IList<decimal> GetPDFYvalsForCurveFitting()
        {
            var list = new List<decimal>();
            var PDF = GetPDF();
            foreach(var val in PDF)
            {
                list.Add(val.Yval);
            }
            return list;
        }

        public decimal GetPDFValue(int timeIndex)
        {
            cache = cache==null? GetPDF():cache;
            return cache[timeIndex].Yval;
        }

        public IList<Point<decimal, decimal>> GetPDF()
        {
            nelsonAalen = new KaplanMeier(observationsInternal);
            var result = new List<Point<decimal, decimal>>();
            var cnt = 0;
            foreach (var set in observationsInternal)
            {
                var survival = nelsonAalen.GetSurvivalOverPeriod(cnt);
                var div = survival;
                var point = new Point<decimal, decimal>(set.unitTime * cnt, (div));
                result.Add(point);
                cnt++;
            }
            return result;
        }
        public decimal MaximumSurvivalValue { get; private set; }
        public int MaximumSurvivalValueTime { get; private set; }
        /// <summary>
        /// S(t) = 1-F(t) where F(t) = 
        /// </summary>
        /// <returns></returns>
        public IList<Point<decimal, decimal>> SurvivalFunction()
        {
           
            MaximumSurvivalValue = 0;
            MaximumSurvivalValueTime = 0;
            nelsonAalen = new KaplanMeier(observationsInternal);
            var result = new List<Point<decimal, decimal>>();
            var cnt = 0;
            foreach (var set in observationsInternal)
            {
                var survival = nelsonAalen.GetSurvivalValueUpToPeriod(cnt + 1);
                
                SetMaximumSurvivalValue(survival,cnt);
                var point = new Point<decimal, decimal>(set.unitTime * cnt, (survival));
                result.Add(point);
                cnt++;
            }
            return result;
        }

        private void SetMaximumSurvivalValue(decimal survival, int maximumSurvivalValueTime)
        {
            if (survival > MaximumSurvivalValue)
            {
                MaximumSurvivalValue = survival;
                MaximumSurvivalValueTime = maximumSurvivalValueTime;
            }
        }

        public IList<Point<decimal, decimal>> GetCDF()
        {
            nelsonAalen = new KaplanMeier(observationsInternal);
            var result = new List<Point<decimal, decimal>>();
            var cnt = 0;
            foreach (var set in observationsInternal)
            {
                var survival = nelsonAalen.GetSurvivalValueUpToPeriod(cnt + 1);
                var point = new Point<decimal, decimal>(set.unitTime * cnt, (1-survival));
                result.Add(point);
                cnt++;
            }
            return result;
        }
    }
}
