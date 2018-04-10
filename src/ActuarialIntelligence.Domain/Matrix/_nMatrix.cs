using System;
using System.Collections.Generic;
using System.Linq;

namespace ActuarialIntelligence.Domain.Matrix
{
    public class _nMatrix
    {
        public IDictionary<int, _nVector> rows { get; private set; }
        public int n { get; private set; }
        private IList<double> DiagonalEntries;
        public _nMatrix(IList<_nVector> rowList, int n)
        {
            rows = new Dictionary<int, _nVector>();
            DiagonalEntries = new List<double>();
            int ctr = 0;
            foreach (var vctor in rowList)
            {
                rows.Add(ctr, vctor);
                ctr++;
            }
            this.n = n;
        }

        public double GetValueAt(int rowPosition, int columnPosition)
        {
            return rows[rowPosition - 1].V(columnPosition);
        }

        public void SetValueAt(int rowPosition, int columnPosition, double value)
        {
            rows[rowPosition - 1].vector[columnPosition - 1] = value;
        }

        public _nVector GetRow(int index)
        {
            return rows[index];
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

        public _nVector GetSubRow(int m, int k)
        {
            var mRows = new List<_nVector>();
            int skipRows = n - m, skipCols = n - k;
            var nVector = new List<double>();
            for (int j = skipCols; j < n; j++)
            {
                nVector.Add(rows[skipRows].vector[j]);
            }
            var tempNVector = new _nVector(nVector);


            return tempNVector;

        }

        public _nMatrix GetSubMatrix(int m)
        {
            var mRows = new List<_nVector>();
            int skipRows = n - m, skipCols = n - m;
            for (int i = skipRows; i < n; i++)
            {
                var nVector = new List<double>();
                for (int j = skipRows; j < n; j++)
                {
                    nVector.Add(rows[i].vector[j]);
                }
                var tempNVector = new _nVector(nVector);
                mRows.Add(tempNVector);
            }
            return new _nMatrix(mRows, m);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"> Row </param>
        /// <param name="k"> Column </param>
        /// <returns></returns>
        public _mnMatrix GetSubMatrix(int m, int k)
        {
            var mRows = new List<_nVector>();
            int skipRows = m, skipCols = k;
            for (int i = skipRows; i < n; i++)
            {
                var nVector = new List<double>();
                for (int j = skipCols; j < n; j++)
                {
                    nVector.Add(rows[i].vector[j]);
                }
                var tempNVector = new _nVector(nVector);
                mRows.Add(tempNVector);
            }
            return new _mnMatrix(mRows, n - k, n - m);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="m"> This is the dimension of the input matrix</param>
        /// <returns></returns>
        public void InsertSubMatrix(_nMatrix matrix, int m)
        {
            int skipRows = n - m, skipCols = n - m;
            for (int i = skipRows; i < n; i++)
            {
                var nVector = new List<double>();
                for (int j = skipRows; j < n; j++)
                {
                    rows[i].vector[j] = matrix.rows[i - skipCols].vector[j - skipRows];
                }
            }
        }

        public void InsertSubMatrix(_mnMatrix matrix, int m, int k)
        {
            int skipRows = n - m, skipCols = n - k;
            for (int i = skipRows; i < n; i++)
            {
                var nVector = new List<double>();
                for (int j = skipCols; j < n; j++)
                {
                    rows[i].vector[j] = matrix.rows[i - skipRows].vector[j - skipCols];
                }
            }
        }

        public _nMatrix MultiplyByScalar(double scalar)
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
            return new _nMatrix(MatrixComponents, n);

        }

        public _nMatrix AddAnotherMatrix(_nMatrix matrix)
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
            return new _nMatrix(MatrixComponents, n);

        }

        public _nMatrix SubtractAnotherMatrix(_nMatrix matrix)
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
            return new _nMatrix(MatrixComponents, n);

        }

        public _nVector MultiplyByVector(_nVector vector)
        {
            double[,] a = new double[n, n];
            for (int j = 1; j <= n; j++)
            {
                for (int i = 1; i <= n; i++)
                {
                    a[i - 1, j - 1] = GetValueAt(j, i) * vector.V(i);
                }
            }

            var vec = new List<double>();
            for (int i = 0; i < n; i++)
            {
                double temp = 0;
                for (int j = 0; j < n; j++)
                {
                    temp += a[i, j];

                }
                vec.Add(temp);
            }

            return new _nVector(vec);
        }

        public _nMatrix MultiplyByAnotherMatrix(_nMatrix matrix)
        {

            _nVector[] _row = new _nVector[n];
            double[] a = new double[n];
            for (int k = 1; k <= n; k++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (int i = 1; i <= n; i++)
                    {
                        var tmp1 = GetValueAt(k, i); var tmp2 = matrix.GetValueAt(i, j);
                        a[j - 1] += GetValueAt(k, i) * matrix.GetValueAt(i, j);
                    }
                    var tmp3 = a[j - 1];
                }

                _row[k - 1] = new _nVector(a.ToList());
                a = new double[n];
            }
            return new _nMatrix(_row.ToList(), n);
        }

        public _nMatrix ReturnTranspose(_nMatrix matrix)
        {
            var tempVectors = new List<_nVector>();
            for (int i = 0; i < n; i++)
            {
                var tempVectorList = new List<double>();
                for (int j = 0; j < n; j++)
                {
                    tempVectorList.Add(GetValueAt(j + 1, i + 1));
                }
                tempVectors.Add(new _nVector(tempVectorList));
            }
            return new _nMatrix(tempVectors, n);
        }





        public _nMatrix ReturnDiagonalInverseMatrix(_nMatrix matrix)
        {
            int dim = matrix.n;
            var identityMatrixClass = new nIdentityMatrix();
            var inverseMatrix = identityMatrixClass.ReturnNIdentityMatrix(dim);

            for (int i = 0; i < dim; i++)
            {
                inverseMatrix.SetValueAt(i + 1, i + 1, (1 / matrix.rows[i].vector[i]));
            }

            return inverseMatrix;
        }

        public void CreateBmatrix(_nMatrix matrix)
        {
            int dim = matrix.n;
            for (int i = 0; i < dim; i++)
            {
                if (i < dim - 1)
                {
                    matrix.rows[i].vector[i + 1] = matrix.rows[i].vector[i + 1] / matrix.rows[i].vector[i];
                }
                matrix.rows[i].vector[i] = 1;
            }
        }

        public void ReplaceDiagonalEntriesWithZero(_nMatrix matrix)
        {
            int dim = matrix.n;
            for (int i = 0; i < dim; i++)
            {
                matrix.rows[i].vector[i] = 0;
            }


        }


        public _nMatrix CreateCopy(_nMatrix matrix)
        {
            var matrixRows = new List<_nVector>();
            int cntr = 0;
            foreach (var vctor in matrix.rows)
            {
                var tempVecList = new List<double>();
                for (int i = 0; i < matrix.n; i++)
                {
                    tempVecList.Add(vctor.Value.vector[i]);
                }
                matrixRows.Add(new _nVector(tempVecList));
                cntr++;
            }

            return new _nMatrix(matrixRows, matrix.n);
        }


        public void ZeroOutRight(_nMatrix matrix)
        {
            int cntr = 0;
            foreach (var vctor in matrix.rows)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i >= cntr + 1)
                    {
                        vctor.Value.vector[i] = 0;
                    }
                }
                cntr++;
            }
        }

        public void ZeroOutLeft(_nMatrix matrix)
        {
            int row = 0;
            int cntr = 0;
            foreach (var vctor in matrix.rows)
            {
                if (row != 0)
                {
                    for (int i = 0; i <= cntr; i++)
                    {
                        vctor.Value.vector[i] = 0;
                    }
                    cntr++;
                }
                row++;
            }
        }


        public _nMatrix AssumeBiDiagonalAndGetInverseofBidiagonalMatrix(_nMatrix matrix)
        {
            var invBmatrixRows = new List<_nVector>();
            var bMatrix = CreateBMatrix(matrix);
            var bMatrixCopy = CreateCopy(bMatrix);
            var nn = matrix.n;

            for (int i = 0; i < nn; i++)
            {
                var bTempVecList = new List<double>();
                AddNZerosToList(bTempVecList, nn);
                bTempVecList[i] = 1;

                for (int j = i + 1; j < (nn); j++)
                {
                    bTempVecList[j] = MultiplyNSubdiagonalEntries(bMatrix, i, j - i);
                }

                invBmatrixRows.Add(new _nVector(bTempVecList));
            }

            var dMatrixInverse = ReturnDiagonalInverseMatrix(matrix);
            var bMatrixInverse = new _nMatrix(invBmatrixRows, nn);
            var biDiagonalInverse = bMatrixInverse.MultiplyByAnotherMatrix(dMatrixInverse);
            //var test = matrix.MultiplyByAnotherMatrix(biDiagonalInverse); // Succeeds!!!
            return biDiagonalInverse;
        }

        public double MultiplyNSubdiagonalEntries(_nMatrix bMatrix, int k, int m)
        {
            var temp = 1d;
            var nn = bMatrix.n;
            for (int i = k; i < k + m; i++)
            {
                var tmp = bMatrix.GetValueAt(i + 1, i + 2) * (-1);
                temp = temp * tmp;
            }
            return temp;
        }

        private _nMatrix CreateBMatrix(_nMatrix matrix)
        {
            var copy = CreateCopy(matrix);
            CreateBmatrix(copy);

            return copy;
        }

        public void AddNZerosToList(IList<double> list, int k)
        {
            for (int i = 0; i < k; i++)
            {
                list.Add(0);
            }
        }



        private static _nMatrix MatrixToThePowerN(int N, _nMatrix copy)
        {
            var temp = copy;
            for (int i = 0; i < N - 1; i++)
            {
                temp = temp.MultiplyByAnotherMatrix(copy);
            }

            return temp;
        }

        public static void ZeroOutRightUptoI(_nMatrix matrix, int I)
        {
            int cntr = 0;
            var n = matrix.n;
            foreach (var vctor in matrix.rows)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i >= cntr + 1 && i < cntr + I && cntr + I < n)
                    {
                        vctor.Value.vector[i] = 0;
                    }
                }
                cntr++;
            }
        }

        public _nMatrix ReturnInverseOfUpperTriangularMatrix(_nMatrix UpperTriangularMatrix)
        {
            var dimN = UpperTriangularMatrix.n;
            var D = ReturnDiagonalInverseMatrix(UpperTriangularMatrix);
            var copy = CreateCopy(UpperTriangularMatrix);
            copy.ReplaceDiagonalEntriesWithZero(copy);
            copy = D.MultiplyByAnotherMatrix(copy);
            var identityClass = new nIdentityMatrix();
            var identity = identityClass.ReturnNIdentityMatrix(dimN);

            var temp = copy.MultiplyByScalar(-1);

            for (int i = 2; i < dimN; i++)
            {
                AddNextPowerTermToMatrixSeries(copy, ref temp, i);
            }

            var inverse = identity.AddAnotherMatrix(temp);

            var copyPlus1 = identity.AddAnotherMatrix(copy);
            var Test = inverse.MultiplyByAnotherMatrix(copyPlus1);

            //var realTest = D.ReturnDiagonalInverseMatrix(D).MultiplyByAnotherMatrix(D).MultiplyByAnotherMatrix(Test);
            return inverse;

        }

        private static void AddNextPowerTermToMatrixSeries(_nMatrix copy, ref _nMatrix temp, int i)
        {
            int remainder = 0;
            Math.DivRem(i, 2, out remainder);
            if (remainder == 0)
            {
                var tmp = MatrixToThePowerN(i, copy);
                //ZeroOutRightUptoI(tmp, i);
                temp = temp.AddAnotherMatrix(tmp);

            }
            else
            {
                var tmp = MatrixToThePowerN(i, copy);
                //ZeroOutRightUptoI(tmp, i);
                temp = temp.SubtractAnotherMatrix(tmp);

            }
        }
    }
}
