using ActuarialIntelligence.Domain.ContainerObjects;
using ActuarialIntelligence.Infrastructure.Data.Dtos;
using ActuarialIntelligence.Infrastructure.Interfaces.Connection_Interfaces;
using ActuarialIntelligence.Infrastructure.Interfaces.Readers_Interfaces;
using System.Collections.Generic;

namespace ActuarialIntelligence.Infrastructure.Readers
{
    public class TermCashFlowSetReader : IDataReader<PlainListTermCashFlowSet>
    {
        private readonly IDataConnection<IList<CashFlowSetDto>> connection;
        private string path;
        public TermCashFlowSetReader(IDataConnection<IList<CashFlowSetDto>> connection
            ,string path)
        {
            this.connection = connection;
            this.path = path;
        }
        public void ClearAndDispose()
        {

        }

        public PlainListTermCashFlowSet GetData()
        {
            var connectionResult = connection.LoadData();
            var cashflowList = new List<TermCashflowYieldSet>();
            foreach(var s in connectionResult)
            {
                cashflowList.Add
                    (new TermCashflowYieldSet
                    (s.cashflow,s.term,s.date,new SpotYield(s.yield
                    ,Domain.Enums.Term.MonthlyEffective)));
            }
            return new PlainListTermCashFlowSet() { cashflowSet = cashflowList, 
                restMethodType = Domain.Enums.RESTMethodType.POST }; 
            
        }
    }
}
