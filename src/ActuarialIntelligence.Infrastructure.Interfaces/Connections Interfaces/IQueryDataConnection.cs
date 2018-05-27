namespace ActuarialIntelligence.Infrastructure.Interfaces.Connection_Interfaces
{ 
    public interface IQueryDataConnection<T>
    {
        T LoadData(string query);
        void ClearAndDispose();
    }
}
