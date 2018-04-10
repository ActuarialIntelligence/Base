using System;

namespace ActuarialIntelligence.Domain.Mathematical_Technique_Objects
{
    public static class SimpleNumericIntegrator
    {
        /// <summary>
        /// This static class numerically integrates the function delegate passed into function with accuracy dx.
        /// </summary>
        /// <param name="lowerBound"></param>
        /// <param name="upperBound"></param>
        /// <param name="dx"></param>
        /// <param name="function"></param>
        /// <returns></returns>
        public static decimal Integrate(decimal lowerBound, decimal upperBound, decimal dx, Func<decimal, decimal> function)
        {
            var cumulativeFunctionValue = 0m;

            if (dx <= 1.5m)
            {
                while (lowerBound < upperBound)
                {
                    var functionValue = function(lowerBound);
                    cumulativeFunctionValue += functionValue * dx;
                    lowerBound += dx;
                    //Console.WriteLine("cumulativeFunctionValue " + cumulativeFunctionValue + " lowerBound " + lowerBound);
                }
                return cumulativeFunctionValue;
            }
            else
            {
                throw new InaccuracyException("dx is not small enough to yield accurate results");
            }
        }



    }

    public class InaccuracyException : Exception
    {
        public InaccuracyException(string message)
            : base(message)
        {

        }
    }
}
