using ActuarialIntelligence.Domain.ContainerObjects;
using System;
using System.Collections.Generic;

namespace ActuarialIntelligence.Domain.NeuronParametrix.Interfaces
{
    public interface IObject 
    {
        double Height { get; set; }
        double Width { get; set; }
        double Weight { get; set; }
        double Elasticity { get; set; }
        IList<Point<int, Func<double, double>>> TestAllObjectPermeabilities();
    }
}
