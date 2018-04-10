using ActuarialIntelligence.Domain.Matrix;
using System;

namespace ActuarialIntelligence.Domain.Mathematical_Technique_Objects
{
    public class GivensRotationMatrix
    {

        double r = 0;
        double c = 0, s = 0, s_0 = 0;

        public GivensRotationMatrix()
        {

        }

        public void AssignCS(double a, double b)
        {
            r = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            c = (a / r);
            s = -1 * (b / r);
            s_0 = (b / r);
        }

        public _nMatrix ReturnGivensMatrix(double a, double b, int position, int n)
        {
            AssignCS(a, b);
            var identityMatrix = new nIdentityMatrix();
            var matrix = identityMatrix.ReturnNIdentityMatrix(n);
            return matrix;
        }
    }
}
