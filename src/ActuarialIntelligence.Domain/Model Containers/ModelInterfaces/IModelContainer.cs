using ActuarialIntelligence.Domain.ContainerObjects;
using System.Collections.Generic;

namespace ActuarialIntelligence.Domain.Model_Containers.ModelInterfaces
{
    public interface IModelContainer
    {
        IList<Point<_3Vector, _3Vector>> VectorPointsList { get; }
    }
}
