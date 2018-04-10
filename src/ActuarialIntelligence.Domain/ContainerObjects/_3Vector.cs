using ActuarialIntelligence.Domain.Enums;
using System;

namespace ActuarialIntelligence.Domain.ContainerObjects
{
    public class _3Vector
    {
        public double a { get; private set; }
        public double b { get; private set; }
        public double c { get; private set; }
        public _3Vector(double a, double b, double c)
        {

            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double V(int position)
        {
            switch (position)
            {
                case 1:
                    return a;
                case 2:
                    return b;
                case 3:
                    return c;
                default: throw new IndexOutOfRangeException("");
            }
        }

        public _3Vector Add(_3Vector vector)
        {
            return new _3Vector(vector.a + a, vector.b + b, vector.c + c);
        }

        public _3Vector Subtract(_3Vector vector)
        {
            return new _3Vector(vector.a - a, vector.b - b, vector.c - c);
        }

        public string ToXML(FromTo fromTo, int index)
        {
            if (fromTo == FromTo.From)
            {
                return "<From" + index + "><a>" + a + "</a><b>" + b + "</b><c>" + c + "</c></From" + index + ">";
            }
            else
            {
                return "<To" + index + "><a>" + a + "</a><b>" + b + "</b><c>" + c + "</c></To" + index + ">";
            }
        }
    }
}
