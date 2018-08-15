# ActuarialIntelligence Framework 
## For an Efficient Business Layer for Actuarial and AI based Reporting.
### DEMO : Graphics Engine built up Domain Driven Design Style. 

Having built this within an n-layered architecture clarifies and ensures separation of concerns. Simply put, it enforces 
good design and coding principles for all extensions and changes.

Additionally, having built this up in Domain-Driven-Design style, the developer is given the advantage of making use of 
all implementations in an almost LEGO like fashion.   

The Domain layer contains all of the Domain level implementations useful in building up your own Reporting/Intelligence 
solutions. 

These include: 
	Interpolation 
	Bond
	Annuity
	Z-Spread
	Kaplan Meier
	Chapman-Kolmogorov
	Black and Scholes pricing
	
To name just a few, the rest of which can be found within:
	ContainerObjects
	Date
	Enums
	Financial Instrument Objects
	Mathematical Technique Objects
	Matrix
	Model Containers
	NeuralLearners
	NeuralMemmories
	NeuralProcessors
	NeuronParametrix
	ObservationObjects
	PnL
	Properties
	Regression
	Time
	ChapmanKolmogorov
	DBHazardPDF
	Hazard
	KaplanMeier

We have included a sample database mainly as a guideline for mining.
There a variety of experimental implementations that we will branch-out.
In this present state, the solution is capable of 'evolving' based on feedback from mining-structures. 

	

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

.NET Version 4.6 and compatible Visual Studio.

### Installing

Visit: https://github.com/ActuarialIntelligence/Base/ and clone the repository as follows:
![Screenshot](Clone.gif)

Once complete, go to your local repository(I.e. where the repository was cloned to) and open the ActuarialIntelligence.sln 
file with Visual Studio.

To see a simple demo of the Domain Driven Design Style Graphics Engine built with C#, set the test application as the startup and simply run:   
![Screenshot](AppStarting.gif)

## Running the tests

All tests can be found within the ActuarialIntelligence.Tests and Threading.Tests projects. 

### Break down into end to end tests

The tests test:
Matrix manipulation and interpolation methods used in evaluating Z-Spreads and Annuity Interest values.
Threading.

The functioning of the DDD-Style Interpolation method, ensures the functioning of all Black and Scholes pricing, 
Bond and Annuity implementations.
 
#### Example:
namespace ActuarialIntelligence.Tests.Numerical																								.
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

## Built With

Visual Studio 2017 Community Edition.

## Evolution Development Sample

![Screenshot](AI.gif)

## Versioning

We use Git/GitExtensions combination for versioning.

## Authors

Rajah Iyer, Jyothiniranjan Pillay
https://www.researchgate.net/profile/Rajah_Iyer
https://www.linkedin.com/in/rajah-iyer-628689168/


## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

HAL
Research Gate

None of the code was obtained from external sources, i.e. the code was written by the author.

# Disclaimer

We have provided test coverage as best as we can and as such we will not be held responsible for any and all losses or damages that may asise from the usage of this software.

