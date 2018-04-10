using System;

namespace ActuarialIntelligence.Domain.Mathematical_Technique_Objects
{
    /// <summary>
    /// Interpolation object used for interpolating values of single variable functions.
    /// </summary>
    public static class Interpolation
    {
        private static decimal i1, i2 = 0;
        private static decimal f = 0;
        private static decimal previousValue = 0;
        /// <summary>
        /// Method to interpolate to a stipulated degree of accuracy the value of a functional.
        /// </summary>
        /// <param name="functional">Function as Func</param>
        /// <param name="testValue1">Interpolation lowerbound</param>
        /// <param name="testValue2">Interpolation upperbound</param>
        /// <param name="interpolationValue"></param>
        /// <returns></returns>
        public static decimal Interpolate(Func<decimal, decimal> functional,
            decimal testValue1, decimal testValue2, decimal interpolationValue)
        {
            decimal tempI = 0;
            i1 = testValue1;
            i2 = testValue2;
            f = interpolationValue;
            bool _continue = true;

            while (_continue)
            {
                tempI = i2;
                previousValue = i2;
                if (functional(i1) == functional(i2)) { break; }
                i2 = nextValue(functional(i1), functional(i2), i1, i2, out _continue);
                i1 = tempI;
                Console.WriteLine(i2);
            }
            return i2;

        }

        private static decimal nextValue(decimal f1, decimal f2,
            decimal i1, decimal i2, out bool _continue)
        {
            _continue = Threshold.Equals((i1 + (i2 - i1) * ((f - f1) / (f2 - f1))), previousValue);
            return (i1 + (i2 - i1) * ((f - f1) / (f2 - f1)));
        }

    }

    internal static class Threshold
    {
        private static decimal accuracyThreshold = 0.000000001m;
        public static bool Equals(decimal currentValue, decimal previousValue)
        {
            bool result = Math.Abs(currentValue - previousValue) < accuracyThreshold ? false : true;
            return result;
        }
    }
}
