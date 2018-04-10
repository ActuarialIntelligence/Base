using System;
using System.Collections.Generic;
using ActuarialIntelligence.Domain.ContainerObjects;
using ActuarialIntelligence.Domain.Financial_Instrument_Objects;
using ActuarialIntelligence.Tests.TestData;
using NUnit.Framework;

namespace ActuarialIntelligence.Tests
{
    [TestFixture]
    [Category("Domain")]
    class BondYieldEvaluatorTests
    {
        private IDictionary<decimal, decimal> dictionary;
        [SetUp]
        public void BeforeEachTest()
        {
            dictionary = new Dictionary<decimal, decimal>()
           {
               {240000m,0.0506250000000000890764212117m},
               {1000000m,0.0302249999999999867579682560m},
               {-3m,0.0231322500000000654912592358m},
               {15m,0.0609000000000003592928991318m},
               {-1000000m,0.0920249999999999844887443174m}
           };
        }

        [TestCaseSource(typeof(BondTestCases), "Details")]
        public void AssertCorrectYieldCalculation(BondDetails element)
        {
            var stripper = new HalfYearlyBondYield(element);
            Assert.IsTrue(isEqualWithinThreshold(dictionary[element.nominal], stripper.GetValue()));
        }

        private bool isEqualWithinThreshold(decimal expected, decimal actual)
        {
            if (Math.Abs(expected - actual) <= 0.0000000001m)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
