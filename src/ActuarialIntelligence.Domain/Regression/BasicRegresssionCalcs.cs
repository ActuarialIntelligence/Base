using System;
using System.Collections.Generic;
using System.Linq;

namespace ActuarialIntelligence.Domain.Regression
{
    public static class BasicRegresssionCalcs
    {
        public static double Variance(IList<double> observations)
        {
            var mean = Mean(observations);
            int n = observations.Count() - 1;
            var result = 0d;
            var sum = 0d;
            foreach (var d in observations)
            {
                sum += Math.Pow((d - mean), 2);
            }
            result = sum / n;
            return result;
        }

        public static double Mean(IList<double> observations)
        {
            var sum = 0d;
            int n = observations.Count();
            foreach (var d in observations)
            {
                sum += d;
            }
            var result = sum / n;
            return result;
        }

        public static decimal Variance(IList<decimal> observations)
        {
            var mean = Mean(observations);
            double n = observations.Count() - 1;
            var result = 0m;
            var sum = 0d;
            foreach (var d in observations)
            {
                sum += (double)Math.Pow((double)(d - mean), 2);
            }
            result = (decimal)((sum) / n);
            return result;
        }

        public static decimal Mean(IList<decimal> observations)
        {
            var sum = 0m;
            int n = observations.Count();
            foreach (var d in observations)
            {
                sum += d;
            }
            var result = sum / n;
            return result;
        }
    }
}
