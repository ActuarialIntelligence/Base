using ActuarialIntelligence.Calculators.Helpers;
using ActuarialIntelligence.Calculators.Interfaces;
using ActuarialIntelligence.Domain.ContainerObjects;
using ActuarialIntelligence.Infrastructure.Interfaces.Readers_Interfaces;

namespace ActuarialIntelligence.Calculators
{
    public class AnnuityCalculator : ICalculate<decimal>
    {
        private readonly IDataReader<PlainListTermCashFlowSet> reader;
        private string url;
        public AnnuityCalculator(IDataReader<PlainListTermCashFlowSet> reader,
            string url)
        {
            this.reader = reader;
            this.url = url;
        }
        public decimal Calculate()
        {
            var readResult = reader.GetData();
            var res = APIConsumerHelper
                .ReceiveHTTPObjectPointer<PlainListTermCashFlowSet, decimal>
                (readResult, url, Domain.Enums.RESTMethodType.POST);
            return res;
        }
    }
}
