using ActuarialIntelligence.Domain.ContainerObjects;
using ActuarialIntelligence.Domain.NeuronParametrix.Interfaces;
using System;
using System.Collections.Generic;

namespace ActuarialIntelligence.Domain.NeuronParametrix
{
    // our ConsciousNeuralObject must be capable of translating and automatically placing methods within this boject.
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

        // in future; the following will be relative to the AI object percieving the following:

        public double MyEdgeRestrictionsOrientationLeft(double parameterIn)
        {
            return (0.5) * parameterIn + 12;
        }

        public double MyEdgeRestrictionsOrientationTop(double parameterIn)
        {
            return (0.5) * parameterIn + 12;
        }

        public double AvailableSurfaceAreaToMoveOverWithinEdgesFromLeft(double parameterIn)
        {
            return MyEdgeRestrictionsOrientationLeft(parameterIn) > 5 ? 1 : 0;
        }
    }
}
