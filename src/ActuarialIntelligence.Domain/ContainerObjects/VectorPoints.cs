using System.Collections.Generic;

namespace ActuarialIntelligence.Domain.ContainerObjects
{
    public class VectorPoints
    {
        public IList<_3Vector> linesTo { get; private set; }
        public _3Vector point { get; private set; }
        public VectorPoints(_3Vector point,
                           IList<_3Vector> linesTo) // line is drawn from this object point to lineTo point.
        {
            this.point = point;
            this.linesTo = linesTo;
        }

    }
}
