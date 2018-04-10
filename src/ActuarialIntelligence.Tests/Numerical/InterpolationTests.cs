using ActuarialIntelligence.Domain.ContainerObjects;
using ActuarialIntelligence.Domain.Enums;
using ActuarialIntelligence.Domain.Financial_Instrument_Objects;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ActuarialIntelligence.Tests.Numerical
{
    [TestFixture]
    [Category("Domain")]
    public class InterpolationTests
    {
        List<TermCashflowYieldSet> cashFlowSet;
        [SetUp]
        public void BeforeEachTest()
        {

            cashFlowSet = new List<TermCashflowYieldSet>()
                        {
                            new TermCashflowYieldSet(42000m    ,1m,new DateTime(2016,12,14)  ,new SpotYield(0.0122m,Term.MonthlyEffective)),
                            new TermCashflowYieldSet(42000m    ,2m,new DateTime(2017,1,17)  ,new SpotYield(0.03432m,Term.MonthlyEffective)),
                            new TermCashflowYieldSet(42000m    ,3m,new DateTime(2017,2,14)  ,new SpotYield(0.0252m,Term.MonthlyEffective)),
                            new TermCashflowYieldSet(42000m    ,4, new DateTime(2017,3,21)  ,new SpotYield(0.01332m,Term.MonthlyEffective)),
                            new TermCashflowYieldSet(56783m    ,5 ,new DateTime(2017,4,14)  ,new SpotYield(0.022452m,Term.MonthlyEffective)),
                            new TermCashflowYieldSet(40000m    ,6 ,new DateTime(2017,5,13)  ,new SpotYield(0.02342m,Term.MonthlyEffective)),
                            new TermCashflowYieldSet(2048000m  ,7 ,new DateTime(2017,6,14)  ,new SpotYield(0.012546m,Term.MonthlyEffective))
                        };


        }

        [Test]
        public void AssertInterpolationTest1()
        {
            var flows = new ListTermCashflowSet(cashFlowSet, Term.MonthlyEffective);
            var zSpread = new ZSpread(flows, 2000000m);
            var result = zSpread.Spread();
            var annuity = new ZSpreadSpecificAnnuity(flows, 30);
            var check = annuity.GetPV(0.0132866482605499030537820089M);
            Assert.IsTrue(IsEqualWithinThreshold(result, 0.0132866482605499030537820089M));
            Assert.IsTrue(IsEqualWithinThreshold(check, 2000000m));
        }

        private bool IsEqualWithinThreshold(decimal a, decimal b)
        {
            if (a - b > 0.0001m || a - b <= 0.0001m)
            {
                return true;
            }
            else { return false; }
        }
    }
}
