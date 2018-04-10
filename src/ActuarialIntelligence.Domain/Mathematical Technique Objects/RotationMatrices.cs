using ActuarialIntelligence.Domain.ContainerObjects;
using System;

namespace ActuarialIntelligence.Domain.Mathematical_Technique_Objects
{
    /// <summary>
    /// Rotation matrix to rotate a vector by an angle.
    /// </summary>
    public static class RotationMatrices
    {
        public static _3Matrix RotateByAngles(double x, double y, double z)
        {
            var xMatrix = RotateX(Math.PI * x);
            var yMatrix = RotateY(Math.PI * y);
            var zMatrix = RotateZ(Math.PI * z);
            return xMatrix.MultiplyByAnotherMatrix(yMatrix).MultiplyByAnotherMatrix(zMatrix);
        }

        private static _3Matrix RotateX(double x)
        {
            _3Vector r1 = new _3Vector(1, 0, 0),
                r2 = new _3Vector(0, Math.Cos(-x), -Math.Sin(-x)),
                r3 = new _3Vector(0, Math.Sin(-x), Math.Cos(-x));

            return new _3Matrix(r1, r2, r3);
        }

        private static _3Matrix RotateY(double y)
        {
            _3Vector r1 = new _3Vector(Math.Cos(-y), 0, Math.Sin(-y)),
                r2 = new _3Vector(0, 1, 0),
                r3 = new _3Vector(-Math.Sin(-y), 0, Math.Cos(-y));

            return new _3Matrix(r1, r2, r3);
        }

        private static _3Matrix RotateZ(double z)
        {
            _3Vector r1 = new _3Vector(Math.Cos(-z), -Math.Sin(-z), 0),
                r2 = new _3Vector(Math.Sin(-z), Math.Cos(-z), 0),
                r3 = new _3Vector(0, 0, 1);

            return new _3Matrix(r1, r2, r3);
        }
    }
}
