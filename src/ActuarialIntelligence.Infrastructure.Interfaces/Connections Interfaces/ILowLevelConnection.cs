using System.Collections.Generic;

namespace ActuarialIntelligence.Infrastructure.Interfaces.Connection_Interfaces
{
    public interface ILowLevelConnection
    {
        IList<string> LoadData(int rowsFrom, int rowsTo, string location);
    }
}
