using System.Collections.Generic;
using System.Linq;

namespace ActuarialIntelligence.Domain.Matrix
{
    public class _mnMatrix
    {
        public IDictionary<int, _nVector> rows { get; private set; }
        public int m { get; private set; }
        public int n { get; private set; }
        public _mnMatrix(IList<_nVector> rowList, int m, int n)
        {
            rows = new Dictionary<int, _nVector>();
            int ctr = 0;
            foreach (var vctor in rowList)
            {
                rows.Add(ctr, vctor);
                ctr++;
            }
            this.n = rows.Count();
            this.m = rows[0].vector.Count();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector">The vector is always a column entity!!</param>
        /// <returns></returns>

        public _nVector MultiplyByVector(_nVector vector)
        {
            double[,] a = new double[m, n];
            for (int j = 1; j <= n; j++)
            {
                for (int i = 1; i <= m; i++)
                {
                    a[i - 1, j - 1] = GetValueAt(j, i) * vector.V(i);
                }
            }

            var vec = new List<double>();
            for (int i = 0; i < n; i++)
            {
                double temp = 0;
                for (int j = 0; j < m; j++)
                {
                    temp += a[j, i];

                }
                vec.Add(temp);
            }

            return new _nVector(vec);
        }

        public double GetValueAt(int rowPosition, int columnPosition)
        {
            return rows[rowPosition - 1].V(columnPosition);
        }

        public _nVector GetRow(int index)
        {
            return rows[index];
        }

        public _mnMatrix MultiplyByScalar(double scalar)
        {
            var MatrixComponents = new List<_nVector>();
            int i = 1, j = 1;
            foreach (var vctor in rows)
            {
                var tmpVctor = new List<double>();
                foreach (var component in vctor.Value.vector)
                {
                    tmpVctor.Add(component * scalar);
                    j++;
                }
                MatrixComponents.Add(new _nVector(tmpVctor));
                j = 1;
                i++;
            }
            return new _mnMatrix(MatrixComponents, i, j);

        }

        public _mnMatrix ReturnTranspose(_mnMatrix matrix)
        {
            var nn = matrix.n;//rows
            var mm = matrix.m;//columns
            var tempVectors = new List<_nVector>();
            for (int i = 0; i < mm; i++)
            {
                var tempVectorList = new List<double>();
                for (int j = 0; j < nn; j++)
                {
                    tempVectorList.Add(matrix.GetValueAt(j + 1, i + 1));
                }
                tempVectors.Add(new _nVector(tempVectorList));
            }
            return new _mnMatrix(tempVectors, mm, nn);
        }

        public _mnMatrix GetSubMatrix(int mm, int k)
        {
            var mRows = new List<_nVector>();
            int skipRows = m - mm, skipCols = m - k;
            for (int i = skipRows; i < m; i++)
            {
                var nVector = new List<double>();
                for (int j = skipCols; j < m; j++)
                {
                    nVector.Add(rows[i].vector[j]);
                }
                var tempNVector = new _nVector(nVector);
                mRows.Add(tempNVector);
            }
            return new _mnMatrix(mRows, mm, k);

        }

        public void InsertSubMatrix(_mnMatrix matrix, int mm, int k)
        {
            int skipRows = m - mm, skipCols = m - k;
            for (int i = skipRows; i < m; i++)
            {
                var nVector = new List<double>();
                for (int j = skipCols; j < m; j++)
                {
                    rows[i].vector[j] = matrix.rows[i - skipRows].vector[j - skipCols];
                }
            }
        }

        public _nVector GetColumn(int index)
        {
            var col = new List<double>();
            foreach (var row in rows)
            {
                col.Add(row.Value.vector[index]);
            }
            return new _nVector(col);
        }

        public _mnMatrix AddAnotherMatrix(_mnMatrix matrix)
        {
            var MatrixComponents = new List<_nVector>();
            int i = 1, j = 1;
            foreach (var vctor in rows)
            {
                var tmpVctor = new List<double>();
                foreach (var component in vctor.Value.vector)
                {
                    tmpVctor.Add(component + matrix.GetValueAt(i, j));
                    j++;
                }
                MatrixComponents.Add(new _nVector(tmpVctor));
                j = 1;
                i++;
            }
            return new _mnMatrix(MatrixComponents, i, j);

        }

        public _mnMatrix SubtractAnotherMatrix(_mnMatrix matrix)
        {
            var MatrixComponents = new List<_nVector>();
            int i = 1, j = 1;
            foreach (var vctor in rows)
            {
                var tmpVctor = new List<double>();
                foreach (var component in vctor.Value.vector)
                {
                    tmpVctor.Add(component - matrix.GetValueAt(i, j));
                    j++;
                }
                MatrixComponents.Add(new _nVector(tmpVctor));
                j = 1;
                i++;
            }
            return new _mnMatrix(MatrixComponents, i, j);

        }


        public _mnMatrix MultiplyMeByNMatrix(_nMatrix matrix)
        {
            _nVector[] _row = new _nVector[n];
            var mm = matrix.rows.Count();
            double[] a = new double[n];
            for (int k = 1; k <= n; k++)
            {
                for (int j = 1; j <= mm; j++)
                {
                    for (int i = 1; i <= mm; i++)
                    {
                        //var tmp1 = GetValueAt(k, i); var tmp2 = matrix.GetValueAt(i, j);
                        a[j - 1] += GetValueAt(k, i) * matrix.GetValueAt(i, j);
                    }
                    // var tmp3 = a[j - 1];
                }

                _row[k - 1] = new _nVector(a.ToList());
                a = new double[n];
            }
            return new _mnMatrix(_row.ToList(), n, mm);
        }

    }
}
