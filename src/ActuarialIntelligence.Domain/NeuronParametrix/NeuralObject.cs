using ActuarialIntelligence.Domain.ContainerObjects;
using ActuarialIntelligence.Domain.NeuronParametrix.Interfaces;
using System;
using System.Collections.Generic;

namespace ActuarialIntelligence.Domain.NeuronParametrix
{
    public class NeuralObject : IObject
    {
        public double Height { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public double Width { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public double Weight { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public double Elasticity { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public IList<Point<int,Func<double,double>>> TestAllObjectPermeabilities()
        {
            return new List<Point<int, Func<double, double>>>();
        }
    }
}
