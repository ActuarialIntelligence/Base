using ActuarialIntelligence.Domain.Date;
using ActuarialIntelligence.Domain.Time;
using ActuarialIntelligence.Infrastructure.Data.Enums;

namespace ActuarialIntelligence.Infrastructure.Interfaces.Readers_Interfaces
{
    public interface IDataReader<T>
    {
        T GetData();
        void ClearAndDispose();
    }

    public interface IDataReaderIdParametric<T>
    {
        T GetData(int id);
        void ClearAndDispose();
    }
    public interface IDataReaderTimeParametric<T>
    {
        T GetData(int timeIndex, string modelId);
    }
    public interface IDataReaderIntParametric<T>
    {
        T GetData(int value, int type, CustomerTimePeriods period);
    }
    public interface IDataReaderHazardParametric<T>
    {
        T GetData(string dateId, string endDateId, DateIncrement increment, string fieldName);
        T GetData(string timeId, string endTimeId, TimeIncrement increment, string fieldName);
    }

    public interface IDataReaderHazardStateParametric<T>
    {
        T GetData(int PopulationGroupID, string dateId, string endDateId, DateIncrement increment, string fieldName, string StateFrom, int noOfTransitions);
        T GetData(string timeId, string endTimeId, TimeIncrement increment, string fieldName, string StateFrom);
    }

    public interface IDataReaderHazardTransitionParametric<T>
    {
        T GetData(string PopulationGroupID, string dateId, string endDateId, DateIncrement increment
            , string expected, int CurrentState, int noOfTransitions);
        T GetData(string timeId, string endTimeId,
            TimeIncrement increment, string expected);
    }

}
