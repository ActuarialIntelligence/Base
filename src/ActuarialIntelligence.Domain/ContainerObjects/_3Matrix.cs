using System.Collections.Generic;

namespace ActuarialIntelligence.Domain.ContainerObjects
{ 
    /// <summary>
    /// 3 by 3 Matrix object
    /// </summary>
    public class _3Matrix
    {

        private IDictionary<int, _3Vector> rows;
        public _3Matrix(_3Vector row1, _3Vector row2, _3Vector row3)
        {
            rows = new Dictionary<int, _3Vector>();
            rows.Add(1, row1);
            rows.Add(2, row2);
            rows.Add(3, row3);
        }

        public double GetValueAt(int rowPosition, int columnPosition)
        {
            return rows[rowPosition].V(columnPosition);
        }

        public _3Vector GetRow(int index)
        {
            return rows[index];
        }

        public _3Vector GetColumn(int index)
        {
            return new _3Vector(GetValueAt(1, index), GetValueAt(2, index), GetValueAt(3, index));
        }

        public _3Matrix MultiplyByScalar(double scalar)
        {
            int i = 0;
            _3Vector[] _row = new _3Vector[3];
            foreach (var pair in rows)
            {
                _row[i] = new _3Vector(pair.Value.a * scalar, pair.Value.b * scalar, pair.Value.c * scalar);
                i++;
            }
            return new _3Matrix(_row[0], _row[1], _row[2]);
        }

        public _3Vector MultiplyByVector(_3Vector vector)
        {
            double[,] a = new double[3, 3];
            for (int j = 1; j <= 3; j++)
            {
                for (int i = 1; i <= 3; i++)
                {
                    a[i - 1, j - 1] = GetValueAt(j, i) * vector.V(i);
                }
            }
            return new _3Vector(a[0, 0] + a[1, 0] + a[2, 0],
                a[0, 1] + a[1, 1] + a[2, 1],
                a[0, 2] + a[1, 2] + a[2, 2]);
        }

        public _3Matrix MultiplyByAnotherMatrix(_3Matrix matrix)
        {
            _3Vector[] _row = new _3Vector[3];
            double[] a = new double[3];
            for (int k = 1; k <= 3; k++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        a[j - 1] += GetValueAt(j, i) * matrix.GetValueAt(i, k);
                    }

                }
                _row[k - 1] = new _3Vector(a[0], a[1], a[2]);
                a = new double[3];
            }
            return new _3Matrix(_row[0], _row[1], _row[2]);
        }
    }
}
