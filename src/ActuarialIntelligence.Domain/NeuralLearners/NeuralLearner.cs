using ActuarialIntelligence.Domain.ContainerObjects;
using ActuarialIntelligence.Domain.NeuralMemmories;
using ActuarialIntelligence.Domain.NeuronParametrix.Interfaces;
using System;
using System.Collections.Generic;

namespace ActuarialIntelligence.Domain.NeuralLearners
{
    /// <summary>
    /// Learners store leaned implementations such as sum etc...
    /// these are to be called via delegate and to be used by the processor.
    /// This will interact with the storage environment objects to store data 
    /// to be used for processing.
    /// </summary>
    public static class NeuralLearner
    {
        public static double SumHeight(IList<IObject> objects)
        {
            var height = 0d;
            foreach(var obj in objects)
            {
                height += obj.Height;
            }
            return height;
        }

        public static NeuralMemmory<int,double> StoreAggregrate(Func<IList<IObject>,double> LearnedDelegate
            , IList<IObject> objects)
        {
            return new NeuralMemmory<int, double>(new Point<int, double>(1,LearnedDelegate(objects))); 
        }

        public static NeuralMemmory<int,IList<double>> StoreAll(IList<IObject> objects)
        {
            var list = new List<double>();
            foreach (var obj in objects)
            {
                list.Add(obj.Height);
            }
            var point = new Point<int, IList<double>>(1, list);
            var nm = new NeuralMemmory<int, IList<double>>(point);
            return nm;
        }
    }
}
