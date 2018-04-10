using ActuarialIntelligence.Domain.ContainerObjects;
using ActuarialIntelligence.Domain.Model_Containers.ModelInterfaces;
using System;
using System.Collections.Generic;

namespace ActuarialIntelligence.Domain.Model_Containers
{
    /// <summary>
    /// SimpleFunctionContainer : Converts Func values into ModelContainer points.
    /// </summary>
    public class SimpleFunctionContainer : IModelContainer
    {
        private readonly Func<double, double, double> function;

        private double stepX;
        private double stepY;
        private int gridSteps;
        public SimpleFunctionContainer(Func<double, double, double> function,
            double stepX, double stepY, int gridSteps)
        {
            this.function = function;
            this.stepX = stepX;
            this.stepY = stepY;
            this.gridSteps = gridSteps;
        }
        /// <summary>
        /// For a 'plane' lighting model : The two vectors here are sufficient (because they are 90 degrees of each other) to find the
        /// normal of the plane through them, and as the vectors have lengths from which they are drawn,
        /// one can apply a plane lighting model
        /// </summary>
        public IList<Point<_3Vector, _3Vector>> VectorPointsList
        {

            get
            {
                var cnt = 0;

                var list = new List<Point<_3Vector, _3Vector>>();
                for (int i = -gridSteps; i < gridSteps; i++)
                {

                    for (int j = -gridSteps; j < gridSteps; j++)
                    {
                        var a1 = new _3Vector(stepX * i, stepY * j, function(stepX * i, stepY * j));
                        var a2 = new _3Vector(stepX * (i + 1), stepY * j, function(stepX * (i + 1), stepY * j));


                        list.Add(new Point<_3Vector, _3Vector>
                            (a1, a2));

                        var b1 = new _3Vector(stepX * i, stepY * j, function(stepX * i, stepY * j));
                        var b2 = new _3Vector(stepX * i, stepY * (j + 1), function(stepX * i, stepY * (j + 1)));

                        list.Add(new Point<_3Vector, _3Vector>
                            (b1, b2));
                        cnt++;
                    }
                }
                return list;
            }
        }
    }
}
