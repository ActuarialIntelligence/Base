using ActuarialIntelligence.Domain.ContainerObjects;
using NUnit.Framework;
using System.Collections.Generic;

namespace ActuarialIntelligence.Tests.TestData
{
    internal static class BondTestCases
    {
        internal static IEnumerable<TestCaseData> Details
        {
            get
            {
                yield return new TestCaseData(new BondDetails(240000, 0.05m, 1, 15m, 0.02m));
                yield return new TestCaseData(new BondDetails(1000000, 0.03m, 1, 17m, 0.02m));
                yield return new TestCaseData(new BondDetails(-3, 0.023m, 1, 23m, 0.02m));
                yield return new TestCaseData(new BondDetails(15, 0.06m, 1, 12m, 0.02m));
                yield return new TestCaseData(new BondDetails(-1000000, 0.09m, 1, 15.5m, 0.02m));

            }
        }
    }
}
