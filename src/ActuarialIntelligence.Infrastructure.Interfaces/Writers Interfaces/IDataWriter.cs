namespace ActuarialIntelligence.Infrastructure.Interfaces.Writers_Interfaces
{
    public interface IDataWriter<P>
    {
        void WriteData(P data);
    }
    public interface IDataWriterTypeParametric<T>
    {
        void WriteData(T value);
    }
}
