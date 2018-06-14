using NUnit.Framework;
using System.Collections.Generic;

namespace Threading.Tests.TestData
{
    internal static class ThreadLoopingTestData
    {
        internal static IEnumerable<TestCaseData> BreaksTestData
        {
            get
            {
                yield return new TestCaseData(1m, 0.2m, 7m);//0.00082
                yield return new TestCaseData(1m, 0.2m, 6.4m);//0.00402
                yield return new TestCaseData(1m, 0.2m, 6.2m);//0.9999      
                yield return new TestCaseData(1m, 0.2m, 6.6m);//0.53983
                yield return new TestCaseData(1m, 0.2m, 6.8m);//0.94295
            }
        }

    }
}
