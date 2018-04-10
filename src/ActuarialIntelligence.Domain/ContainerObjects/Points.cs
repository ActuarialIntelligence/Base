using System.Collections.Generic;
using System.Linq;

namespace ActuarialIntelligence.Domain.ContainerObjects
{
    public class Points
    {
        public IList<Point<decimal, decimal>> PointList { get; private set; }
        public Points(IList<Point<decimal, decimal>> pointList)
        {
            PointList = pointList;
        }

        public double[] GetXs()
        {
            IList<double> Xs = new List<double>();
            foreach (var point in PointList)
            {
                Xs.Add((double)point.Xval);
            }
            return Xs.ToArray();
        }

        public double[] Get1MinusYs()
        {
            IList<double> Ys = new List<double>();
            foreach (var point in PointList)
            {
                Ys.Add(1 - (double)point.Yval);
            }
            return Ys.ToArray();
        }
    }
}
