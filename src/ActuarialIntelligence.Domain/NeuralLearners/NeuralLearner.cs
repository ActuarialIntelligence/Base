using ActuarialIntelligence.Domain.ContainerObjects;
using ActuarialIntelligence.Domain.NeuralMemmories;
using ActuarialIntelligence.Domain.NeuronParametrix.Interfaces;
using ActuarialIntelligence.Domain.Regression;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ActuarialIntelligence.Domain.NeuralLearners
{
    /// <summary>
    /// Learners store leaned implementations such as sum etc...
    /// these are to be called via delegate and to be used by the processor.
    /// This will interact with the storage environment objects to store data 
    /// to be used for processing.
    /// 
    /// I donot want this object to be externally dependant 
    /// </summary>
    public static class NeuralLearner
    {
        public static double SumHeight(IList<IObject> objects)
        {
            var sumHeight = 0d;
            foreach(var obj in objects)
            {
                sumHeight += obj.Height;
            }
            return sumHeight;
        }

        /// Returns Memmory object
        public static NeuralMemmory<int, StorageType> StoreAggregate<StorageType>
            (Func<IList<IObject>, StorageType> LearnedDelegate
            , IList<IObject> objects)
        {
            return new NeuralMemmory<int, StorageType>(
                new Point<int, StorageType>(1,LearnedDelegate(objects))); 
        }

        /// Returns Memmory object
        public static NeuralMemmory<int,IList<StoreType>> StoreAll<StoreType>(IList<IObject> objects
            , string WhatToStore)
        {
            var list = new List<StoreType>();
            foreach (var obj in objects)
            {
                var result = (StoreType)GetObjectPropertyValue(obj, WhatToStore);
                list.Add(result);
            }
            var point = new Point<int, IList<StoreType>>(1, list);
            var nm = new NeuralMemmory<int, IList<StoreType>>(point);
            return nm;
        }

        private static object GetObjectPropertyValue(object src, string propName)
        {
            var result = src.GetType().GetProperty(propName).GetValue(src, null);
            return result;
        }

        private static void SetPropertyValues<U>(string propertyName,
            object objectInconcern, U valueToSet)
        {
            var prop = objectInconcern.GetType().GetProperty(propertyName
                , BindingFlags.Public | BindingFlags.Instance);

            var types = prop != null && prop.ToString() != "" ? prop.ToString().Split(' ')[0] : "";
            var typeToParse = types.Replace("System.", "");

            if (null == prop || !prop.CanWrite || types == "") return;
            prop.SetValue(objectInconcern, valueToSet, null);
        }
    }
    /// <summary>
    /// These two classes are tightly coupled.
    /// </summary>
    public static class NeuralImagination
    {
        // Extrapolate via a simple quadratic fit all MemmoryStoredValues
        // And store the delegate Equation Pointer.
        public static Dictionary<IObject, Func<double, double>>
            ExtrapolateAllObjectMethods(IList<IObject> objects, int testThreshold)
        {
            var rnd = new Random();
            var funcPerObjectPermiationMethodDictionary =
                    new Dictionary<IObject, Func<double, double>>();
            foreach (var obj in objects)
            {

                var allObjectPermeabilities = obj.TestAllObjectPermeabilities();
                foreach (var objectFunction in allObjectPermeabilities)
                {
                    var regressionPoints = new List<double>();
                    for (int i = 0; i < testThreshold; i++)
                    {
                        double randomValue = rnd.NextDouble();
                        regressionPoints.Add(objectFunction.Yval(randomValue));
                    }
                    funcPerObjectPermiationMethodDictionary.Add(obj,
                        UnivariateRegressionFitting.
                        ExponentialDistributionFit(regressionPoints));
                }
            }
            return funcPerObjectPermiationMethodDictionary;
        }
    }
}
