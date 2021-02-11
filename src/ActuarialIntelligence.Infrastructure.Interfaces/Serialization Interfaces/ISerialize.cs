namespace ActuarialIntelligence.Infrastructure.Interfaces.Serialization_Interfaces
{
    public interface ISerialize
    {
        T Deserialize<T>(string input);
        string Serialize<T>(T ObjectToSerialize);
    }
}
